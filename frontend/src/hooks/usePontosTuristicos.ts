import { useState, useCallback } from "react";
import api from "../services/api";
import { PontoTuristicoPaginado } from "../interfaces/PontoTuristico";

export const usePontosTuristico = () => {
    const [dados , setDados] = useState<PontoTuristicoPaginado | null>(null);
    const [loading, setLoading] = useState(false);

    const caregarPontosTuristicos = useCallback(async (pagina: number, busca = '') => {
        setLoading(true);
        try {
            const response = await api.get<PontoTuristicoPaginado>(
            `/PontosTuristicos?pagina=${pagina}&busca=${busca}`
        );
        setDados(response.data);
        } catch (error) {
            console.log("Erro ao carregar dados da API", error);
        } finally {
            setLoading(false);
        }
    }, []);

    return { dados, loading, caregarPontosTuristicos };
}

