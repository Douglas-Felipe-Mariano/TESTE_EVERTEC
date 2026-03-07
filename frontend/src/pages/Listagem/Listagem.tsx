import React, { useEffect, useState} from "react";
import { Link } from "react-router-dom";
import { Search, MapPin, Plus, Filter } from "lucide-react";
import { usePontosTuristico } from "../../hooks/usePontosTuristicos";
import './Listagem.css';

const Listagem: React.FC = () => {
    const [busca, setBusca] = useState('');
    const { dados, loading, caregarPontosTuristicos } = usePontosTuristico();

    useEffect(() => {
        caregarPontosTuristicos(1, busca);
    }, [caregarPontosTuristicos, busca]);

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
                            onChange={(e) => setBusca(e.target.value)}
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
                {dados?.itens.map(ponto => (
                    <div key={ponto.id} className="point-card">
                        <div className="card-badge">
                            <MapPin size={16} />
                        </div>
                        
                        <div className="card-content">
                            <h3 className="card-title">{ponto.nome}</h3>
                            <p className="card-description">{ponto.descricao}</p>

                            <div className="card-location">
                                <MapPin size={16} className="location-icon"/>
                                <span>{ponto.cidade}, {ponto.localizacao}</span>
                            </div>
                            
                            <div className="card-footer">
                                <span className="card-date">
                                    Cadastrado em {new Date(ponto.dataCriacao).toLocaleDateString('pt-BR')}
                                </span>
                            </div>
                        </div>
                    </div>
                ))}
            </div>

            {dados?.itens.length === 0 && !loading && (
                <div className="empty-state">
                    <MapPin size={64} className="empty-icon" />
                    <h3>Nenhum ponto turístico encontrado</h3>
                    <p>Que tal cadastrar o primeiro ponto turístico?</p>
                    <Link to="/novo" className="btn btn-primary">
                        <Plus size={18} />
                        Cadastrar Primeiro Ponto
                    </Link>
                </div>
            )}
        </div>
    )
};

export default Listagem;