const storeData = (key, value) => {    
        localStorage.setItem(key, value);   
    }

const retrieveData = (key) => {    
        try{
            let value = localStorage.getItem(key);
            return value;
        }
        catch{
            return false;
        }  
    }
const clear = () => {
    localStorage.clear();
}
export { storeData, retrieveData, clear };