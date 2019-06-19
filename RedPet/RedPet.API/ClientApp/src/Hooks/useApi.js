import { useState, useEffect, useContext } from 'react'
import { MessageContext } from '../contexts/MessageContext';

const useApi = async (apiCall, showMessage) => {
    const apiResponse = await apiCall;
    
    const ok = apiResponse.ok;

    if (!ok) {
        if (apiResponse.status === 500) {
            const message = 'Se produjo un error intentando conectar al servidor. Intente de nuevo mas tarde.';
            showMessage(message, 'error');
        }
    }

    return apiResponse;
}

export default useApi;