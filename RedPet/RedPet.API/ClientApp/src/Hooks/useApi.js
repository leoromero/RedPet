import { useState, useEffect, useContext } from 'react'
import { MessageContext } from '../contexts/MessageContext';

const useApi = async (apiCall, showMessage) => {
    const apiResponse = await apiCall;
    if(!apiResponse.ok){
        showMessage('Se produjo un error intentando conectar al servidor. Intente de nuevo mas tarde.', 'error');
    }
    const ok = apiResponse.ok;
    const result = apiResponse.result;
    
    return {ok, result};
}

export default useApi;