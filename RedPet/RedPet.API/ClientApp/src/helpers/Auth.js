import jsonwebtoken from 'jsonwebtoken';
import Api from "./Api";
import { storeData, retrieveData, clear } from "./Storage";

const storeTokens = (accessToken, refreshToken) => {
    storeData("accessToken", accessToken);
    storeData("refreshToken", refreshToken);
};

const storeUser = (user) => {
    storeData("user", JSON.stringify(user));
};

const getUserFromToken = (token) => {
    let decodedToken = jsonwebtoken.decode(token, { complete: true, json: true });
    return {
        username: decodedToken.payload.sub,
        id: decodedToken.payload.id,
        role: decodedToken.payload.role,
        isCustomer: decodedToken.payload.role === "Customer",
        isProvider: decodedToken.payload.role === "Provider",        
    };
};
export default {
    retrieveAccessToken: () => {
        return retrieveData("accessToken");
    },
    retrieveRefreshToken: () => {
        return retrieveData("refreshToken");
    },
    retrieveUser: () => {
        let user = retrieveData("user");
        return JSON.parse(user);
    },
    login: async (username, password) => {
        let response = await Api.login(username, password);
        console.log(response);
        if (response.ok) {
            storeTokens(response.accessToken, response.refreshToken);
            let user = getUserFromToken(response.accessToken);
            storeUser(user);
            return {
                ok: true,
                accessToken: response.accessToken,
                refreshToken: response.refreshToken,
                user
            };
        }

        return {
            ok: false,
            status: response.status,
            errors: response.errors
        }
    },
    loginWithFacebook: async (accessToken) => {
        let response = await Api.externalAuth().facebook(accessToken);
        console.log(response);
        if (response.ok) {
            storeTokens(response.result.accessToken, response.result.refreshToken);
            let user = getUserFromToken(response.result.accessToken);
            storeUser(user);
            return {
                ok: true,
                accessToken: response.result.accessToken,
                refreshToken: response.result.refreshToken,
                user
            };
        }

        return {
            ok: false,
            errors: response.errors
        }
    },
    logout: () => {
        clear();
    },
    storeTokens,
    storeUser,
    getUserFromToken

};