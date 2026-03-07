import { useState, useCallback } from "react";
import api from "../services/api";
import { Estado, PontoTuristico } from "../interfaces/PontoTuristico";

export const usePontosTuristicosActions = () => {
    const [loading, setLoading] = useState(false);

    const criarPonto = useCallback(async (dados: any): Promise<boolean> => {
        setLoading(true);
        try {
            await api.post('/PontosTuristicos', dados);
            return true;
        } catch (error) {
            return false;
        } finally {
            setLoading(false);
        }
    }, []);

    const editarPonto = useCallback(async (id: number, dados: any): Promise<boolean> => {
        setLoading(true);
        try {
            await api.put(`/PontosTuristicos/${id}`, dados);
            return true;
        } catch (error) {
            return false;
        } finally {
            setLoading(false);
        }
    }, []);

    const excluirPonto = useCallback(async (id: number): Promise<boolean> => {
        setLoading(true);
        try {
            await api.delete(`/PontosTuristicos/${id}`);
            return true;
        } catch (error) {
            return false;
        } finally {
            setLoading(false);
        }
    }, []);

    const buscarPontoPorId = useCallback(async (id: number): Promise<PontoTuristico | null> => {
        setLoading(true);
        try {
            const response = await api.get<PontoTuristico>(`/PontosTuristicos/${id}`);
            return response.data;
        } catch (error) {
            return null;
        } finally {
            setLoading(false);
        }
    }, []);

    const buscarEstados = useCallback(async (): Promise<Estado[]> => {
        try {
            const response = await api.get<Estado[]>('/PontosTuristicos/estados');
            return response.data;
        } catch (error) {
            return [];
        }
    }, []);

    return { 
        criarPonto, 
        editarPonto, 
        excluirPonto, 
        buscarPontoPorId, 
        buscarEstados, 
        loading 
    };
};