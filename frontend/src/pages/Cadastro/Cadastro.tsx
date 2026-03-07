import React, { useState, useEffect} from "react";
import { useNavigate } from "react-router-dom";
import { ArrowLeft, Save, MapPin, AlertCircle } from "lucide-react";
import api from "../../services/api";
import { Estado } from "../../interfaces/PontoTuristico";
import './Cadastro.css';
import axios from "axios";

const Cadastro: React.FC = () => {
    const navigate = useNavigate();
    const [estados, setEstados] = useState<Estado[]>([]);
    const [cidades, setCidades] = useState<string[]>([]);
    const [loadingCidades, setLoadingCidades] = useState(false);

    const [formData, setFormData] = useState({
        nome: '',
        descricao: '',
        localizacao: '',
        cidade: '',
        estadoId: 0,
    });

    useEffect(() => {
        api.get<Estado[]>('/PontosTuristicos/estados')
           .then(response => setEstados(response.data))
           .catch(error => console.error("Erro ao carregar estados:", error));
    },[]);

    useEffect(() => {
        if(formData.estadoId > 0) {
            const estadoSelecionado = estados.find(e => e.id === formData.estadoId);
            if(estadoSelecionado) {
                setLoadingCidades(true);
                axios.get(`https://servicodados.ibge.gov.br/api/v1/localidades/estados/${estadoSelecionado.sigla}/municipios`)
                .then(response => {
                    const nomesCidades = response.data.map((cidade: any) => cidade.nome);
                    setCidades(nomesCidades);
                })
                .finally(() => setLoadingCidades(false));   
            }
        } else {
            setCidades([]);
        }   
    }, [formData.estadoId, estados]);   

    const handleSubmit = async (e: React.FormEvent) => {    
        e.preventDefault();

        if (formData.descricao.length > 100) {
            return alert("A descrição não pode ter mais de 100 caracteres.");
        }

        try
        {
            await api.post('/PontosTuristicos', formData);
            alert("Ponto turístico cadastrado com sucesso!");
            navigate("/");
        } catch (error) {
            console.error("Erro ao cadastrar ponto turístico:", error);
            alert("Ocorreu um erro ao cadastrar o ponto turístico. Por favor, tente novamente.");
        }
    };  

    return (
        <div className="container">
            <div className="page-header">
                <div className="page-title-section">
                    <button onClick={() => navigate(-1)} className="back-button">
                        <ArrowLeft size={20} />
                        Voltar
                    </button>
                    <h1 className="page-title">
                        <MapPin size={32} />
                        Cadastrar Ponto Turístico
                    </h1>
                    <p className="page-subtitle">
                        Compartilhe um novo destino incrível com outros viajantes
                    </p>
                </div>
            </div>

            <div className="form-container">
                <form onSubmit={handleSubmit} className="cadastro-form">
                    <div className="form-section">
                        <h3 className="section-title">Informações Básicas</h3>
                        
                        <div className="form-group">
                            <label className="form-label">Nome do Ponto Turístico</label>
                            <input 
                                required
                                type="text"
                                className="form-input"
                                value={formData.nome}
                                onChange={e => setFormData({...formData, nome: e.target.value})}
                                placeholder="Ex: Cristo Redentor, Praia de Copacabana..."
                            />
                        </div>

                        <div className="form-group">
                            <label className="form-label">Descrição</label>
                            <textarea 
                                required
                                maxLength={100}
                                rows={3}
                                className="form-input"
                                value={formData.descricao}
                                onChange={e => setFormData({...formData, descricao: e.target.value})}
                                placeholder="Descreva brevemente o que torna este lugar especial..."
                            />
                            <div className="char-counter">
                                <span className={formData.descricao.length > 80 ? 'warning' : ''}>
                                    {formData.descricao.length}/100 caracteres
                                </span>
                            </div>
                        </div>
                    </div>

                    <div className="form-section">
                        <h3 className="section-title">Localização</h3>
                        
                        <div className="form-row">
                            <div className="form-group">
                                <label className="form-label">Estado</label>
                                <select 
                                    required
                                    className="form-input"
                                    value={formData.estadoId}
                                    onChange={e => setFormData({...formData, estadoId: Number(e.target.value), cidade: ''})}
                                >
                                    <option value="">Selecione um estado...</option>
                                    {estados.map(estado =>(
                                        <option key={estado.id} value={estado.id}>{estado.nome}</option>
                                    ))}
                                </select>
                            </div>
                                
                            <div className="form-group">
                                <label className="form-label">Cidade</label>
                                <input 
                                    name="cidade"
                                    list="lista-cidades"
                                    required
                                    className="form-input"
                                    placeholder={loadingCidades ? "Carregando cidades..." : "Digite ou selecione a cidade"}
                                    disabled={formData.estadoId === 0 || loadingCidades}
                                    type="text"
                                    value={formData.cidade}
                                    onChange={(e) => setFormData({ ...formData, cidade: e.target.value })}   
                                />
                                <datalist id="lista-cidades">
                                    {cidades.map((cidade, index) => (
                                        <option key={index} value={cidade} />
                                    ))}
                                </datalist>
                                {loadingCidades && <div className="loading-indicator">Carregando cidades...</div>}
                            </div>
                        </div>

                        <div className="form-group">
                            <label className="form-label">Localização Específica</label>
                            <input 
                                required 
                                type="text"
                                className="form-input"
                                value={formData.localizacao}
                                onChange={e => setFormData({...formData, localizacao: e.target.value})}
                                placeholder="Ex: Rua das Flores, 123 - Centro"
                            />
                        </div>
                    </div>

                    <div className="form-actions">
                        <button type="button" onClick={() => navigate(-1)} className="btn btn-secondary">
                            Cancelar
                        </button>
                        <button type="submit" className="btn btn-success">
                            <Save size={20} />
                            Salvar Ponto Turístico
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Cadastro;