import React, { useEffect, useState} from "react";
import { Link } from "react-router-dom";
import { Search, MapPin, Plus, Edit, Trash2 } from "lucide-react";
import { usePontosTuristico } from "../../hooks/usePontosTuristicos";
import { usePontosTuristicosActions } from "../../hooks/usePontosTuristicosActions";
import Pagination from "../../components/Pagination/Pagination";
import ConfirmModal from "../../components/ConfirmModal/ConfirmModal";
import './Listagem.css';

const Listagem: React.FC = () => {
    const [busca, setBusca] = useState('');
    const [paginaAtual, setPaginaAtual] = useState(1);
    const [itensPorPagina] = useState(6);
    const [cartoesExpandidos, setCartoesExpandidos] = useState<Set<number>>(new Set());

    const toggleExpandir = (id: number) => {
        setCartoesExpandidos(prev => {
            const novo = new Set(prev);
            if (novo.has(id)) {
                novo.delete(id);
            } else {
                novo.add(id);
            }
            return novo;
        });
    };

    const [modalExcluir, setModalExcluir] = useState<{isOpen: boolean, pontoId?: number, pontoNome?: string}>({
        isOpen: false
    });
    
    const { dados, loading, caregarPontosTuristicos } = usePontosTuristico();
    const { excluirPonto, loading: loadingAction } = usePontosTuristicosActions();

    useEffect(() => {
        caregarPontosTuristicos(paginaAtual, busca, itensPorPagina);
    }, [caregarPontosTuristicos, paginaAtual, busca, itensPorPagina]);

    const handleBuscaChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setBusca(e.target.value);
        setPaginaAtual(1); 
    };

    const handlePageChange = (novaPagina: number) => {
        setPaginaAtual(novaPagina);
        window.scrollTo({ top: 0, behavior: 'smooth' });
    };

    const abrirModalExcluir = (id: number, nome: string) => {
        setModalExcluir({
            isOpen: true,
            pontoId: id,
            pontoNome: nome
        });
    };

    const fecharModalExcluir = () => {
        setModalExcluir({ isOpen: false });
    };

    const confirmarExclusao = async () => {
        if (modalExcluir.pontoId) {
            const sucesso = await excluirPonto(modalExcluir.pontoId);
            if (sucesso) {
                
                caregarPontosTuristicos(paginaAtual, busca, itensPorPagina);
                fecharModalExcluir();
                
                
                if (dados && dados.itens.length === 1 && paginaAtual > 1) {
                    setPaginaAtual(paginaAtual - 1);
                }
            } else {
                alert("Erro ao excluir o ponto turístico. Tente novamente.");
            }
        }
    };

    const totalPages = dados ? Math.ceil(dados.contaRegistros / itensPorPagina) : 0;

    return (
        <div className="container">
            <div className="page-header">
                <div className="page-title-section">
                    <h1 className="page-title">Explore Pontos Turísticos</h1>
                    <p className="page-subtitle">Descubra os melhores destinos para visitar</p>
                </div>

                <div className="page-actions">
                    <div className="search-container">
                        <Search size={20} className="search-icon"/>
                        <input
                            type="text"
                            placeholder="Buscar por nome, cidade ou descrição..."
                            value={busca}
                            onChange={handleBuscaChange}
                            className="search-input"
                        />
                    </div>

                    <Link to="/novo" className="btn btn-primary">
                        <Plus size={20}/>
                        Novo Ponto
                    </Link>
                </div>
            </div>

            {loading && (
                <div className="loading">
                    <div className="loading-spinner"></div>
                    <p>Carregando pontos turísticos...</p>
                </div>
            )}

                <div className="points-grid">
                {dados?.itens.map(ponto => {
                    const expandido = cartoesExpandidos.has(ponto.id);
                    return (
                    <div key={ponto.id} className={`point-card${expandido ? ' point-card--expandido' : ''}`}>
                        <button
                            className="card-badge"
                            onClick={() => toggleExpandir(ponto.id)}
                            title={expandido ? "Recolher" : "Expandir"}
                            aria-label={expandido ? "Recolher cartão" : "Expandir cartão"}
                        >
                            <MapPin size={16} />
                        </button>
                        
                        <div className="card-content">
                            <div className="card-title-row">
                                <h3 className={`card-title${expandido ? ' card-title--expandido' : ''}`}>
                                    {ponto.nome}
                                </h3>
                            </div>
                            <p className={`card-description${expandido ? ' card-description--expandido' : ''}`}>{ponto.descricao}</p>

                            <div className={`card-location${expandido ? ' card-location--expandido' : ''}`}>
                                <MapPin size={16} className="location-icon"/>
                                <span>{ponto.cidade}, {ponto.localizacao}</span>
                            </div>
                            
                            <div className="card-footer">
                                <span className="card-date">
                                    Cadastrado em {new Date(ponto.dataCriacao).toLocaleDateString('pt-BR')}
                                </span>
                                <div className="card-actions">
                                    <Link
                                        to={`/editar/${ponto.id}`}
                                        className="action-btn btn-edit"
                                        title="Editar ponto"
                                    >
                                        <Edit size={14} />
                                    </Link>
                                    <button
                                        onClick={() => abrirModalExcluir(ponto.id, ponto.nome)}
                                        className="action-btn btn-delete"
                                        title="Excluir ponto"
                                    >
                                        <Trash2 size={14} />
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                    );
                })}
            </div>            {dados?.itens.length === 0 && !loading && (
                <div className="empty-state">
                    <MapPin size={64} className="empty-icon" />
                    <h3>Nenhum ponto turístico encontrado</h3>
                    <p>Que tal cadastrar o ponto turístico?</p>
                    <Link to="/novo" className="btn btn-primary">
                        <Plus size={18} />
                        Cadastrar Ponto Turistico
                    </Link>
                </div>
            )}

            {dados && dados.itens.length > 0 && (
                <Pagination
                    currentPage={paginaAtual}
                    totalPages={totalPages}
                    onPageChange={handlePageChange}
                    totalItems={dados.contaRegistros}
                    itemsPerPage={itensPorPagina}
                />
            )}
            
            <ConfirmModal
                isOpen={modalExcluir.isOpen}
                onClose={fecharModalExcluir}
                onConfirm={confirmarExclusao}
                title="Excluir Ponto Turístico"
                message={`Tem certeza que deseja excluir o ponto "${modalExcluir.pontoNome}"? Esta ação não pode ser desfeita.`}
                confirmText="Excluir"
                cancelText="Cancelar"
                isLoading={loadingAction}
            />
        </div>
    )
};

export default Listagem;