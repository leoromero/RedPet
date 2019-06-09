import Config from "../config/config";
import AuthHelper from "./Auth";

const makeApiCall = async (url, method, body) => {
    let headers = { 'Content-Type': 'application/json', 'api-version': '1', "Authorization": '' };
    let authToken = AuthHelper.retrieveAccessToken();
    if (authToken) {
        headers.Authorization = "bearer " + authToken;
    }

    try {
        let response = await fetch(url, {
            method: method,
            headers: headers,
            body: body
        });
        if (!response.ok) {
            if (response.status === 401) {
                let refreshResponse = await refreshToken();
                if (refreshResponse) {
                    return makeApiCall(url, method, body);
                }
            }
        }
        return response;
    }
    catch{
        return false;
    }

};

const refreshToken = async () => {
    let authToken = AuthHelper.retrieveAccessToken();
    let refToken = AuthHelper.retrieveRefreshToken();
    let headers = { 'Content-Type': 'application/json', 'api-version': '1' };

    let body = JSON.stringify({
        AuthToken: authToken,
        RefreshToken: refToken
    });

    let response = await fetch(Config.apiURLs.refreshToken, {
        method: "post",
        headers: headers,
        body: body
    });

    if (response.ok) {
        let jsonResponse = await response.json();

        AuthHelper.storeTokens(jsonResponse.authToken, jsonResponse.refreshToken);

        return true;
    }

    return false;
};
const errorReturn = (errors) => {
    if (errors) {
        return {
            ok: false,
            errors: errors
        };
    }

    return { ok: false };
}
export default {
    parameters: {
        vaccines: async () => {
            const vaccines = [{
                id: '1',
                name: 'vacuna1',
                applied: true,
                vaccinationDate: null
            },
            {
                id: '2',
                name: 'vacundasdsadsada2',
                applied: false,
                vaccinationDate: null
            }];

            return { ok: true, result: vaccines };
        },
        breeds: async () => {
            let response = await makeApiCall(Config.apiURLs.breeds, "get");
            try {
                if (!response) {
                    return errorReturn();
                }

                let jsonResponse = await response.json();
                if (response.ok) {
                    return {
                        ok: true,
                        result: jsonResponse
                    };
                }
                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
        petSizes: async () => {
            let response = await makeApiCall(Config.apiURLs.petSizes, "get");
            try {
                if (!response) {
                    return errorReturn();
                }

                let jsonResponse = await response.json();
                if (response.ok) {
                    return {
                        ok: true,
                        result: jsonResponse
                    };
                }
                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
        hairTypes: async () => {
            let response = await makeApiCall(Config.apiURLs.hairTypes, "get");
            try {
                if (!response) {
                    return errorReturn();
                }

                let jsonResponse = await response.json();
                if (response.ok) {
                    return {
                        ok: true,
                        result: jsonResponse
                    };
                }

                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
        weightRanges: async () => {
            let response = await makeApiCall(Config.apiURLs.weightRanges, "get");
            try {
                if (!response) {
                    return errorReturn();
                }

                let jsonResponse = await response.json();
                if (response.ok) {
                    return {
                        ok: true,
                        result: jsonResponse
                    };
                }

                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        }
    },
    login: async (username, password) => {
        let response = await makeApiCall(Config.apiURLs.login, "post", JSON.stringify({
            "userName": username,
            "password": password
        }));
        try {
            if (!response) {
                return errorReturn();
            }

            let jsonResponse = await response.json();
            if (response.ok) {
                return {
                    ok: true,
                    accessToken: jsonResponse.authToken,
                    refreshToken: jsonResponse.refreshToken
                };
            }
            return errorReturn(jsonResponse.errors);
        }
        catch{
            return errorReturn();
        }
    },
    externalAuth: () => {
        return {
            facebook: async (token) => {
                let response = await makeApiCall(Config.apiURLs.fbkLogin, "post", JSON.stringify({
                    'accessToken': token
                }));
                try {
                    if (!response) {
                        return errorReturn();
                    }

                    let jsonResponse = await response.json();
                    if (response.ok) {
                        return {
                            ok: true,
                            result: {
                                accessToken: jsonResponse.authToken,
                                refreshToken: jsonResponse.refreshToken
                            }
                        };
                    }

                    return errorReturn(jsonResponse.errors);
                }
                catch{
                    return errorReturn();
                }
            }
        }
    },
    roles: async () => {
        let response = await makeApiCall(Config.apiURLs.roles, "get");

        try {
            if (!response) {
                return errorReturn();
            }

            let jsonResponse = await response.json();
            if (response.ok) {
                return {
                    ok: true,
                    result: {
                        roles: jsonResponse
                    }
                };
            }

            return errorReturn(jsonResponse.errors);
        }
        catch{
            return errorReturn();
        }
    },
    customers: {
        pets: async (userid) => {
            let response = await makeApiCall(Config.apiURLs.customers + '/' + userid + '/pets', "get");
            try {
                // if (!response) {
                //     return errorReturn();
                // }
                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true,
                        result: jsonResponse
                    };
                }


                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
        create: async (username, password, firstname, lastname, roleid) => {
            let body = JSON.stringify({ "username": username, "password": password, "firstname": firstname, "lastname": lastname, "roleid": roleid ? roleid : 0 });
            let response = await makeApiCall(Config.apiURLs.customers, "post", body);

            try {
                if (!response) {
                    return errorReturn();
                }
                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true
                    };
                }

                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
        read: async () => {
            let response = await makeApiCall(Config.apiURLs.customers, "get");

            try {
                if (!response) {
                    return errorReturn();
                }
                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true,
                        users: jsonResponse
                    };
                }

                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
        getById: async (id) => {
            let response = await makeApiCall(Config.apiURLs.customers + '/' + id, "get");

            try {
                if (!response) {
                    return errorReturn();
                }
                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true,
                        user: jsonResponse
                    };
                }

                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
        update: async (userid, username, currentPassword, newPassword, firstname, lastname, roleid) => {
            let body = JSON.stringify({ "userName": username, "currentPassword": currentPassword, "password": newPassword, "firstName": firstname, "lastName": lastname, "roleId": roleid ? roleid : 0 });
            let response = await makeApiCall(Config.apiURLs.customers + "/" + userid, "put", body);

            try {
                if (!response) {
                    return errorReturn();
                }
                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true
                    };
                }

                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
        delete: async (userid) => {
            let response = await makeApiCall(Config.apiURLs.customers + "/" + userid, "delete");

            try {
                if (!response)
                    return errorReturn();

                if (response.ok) {
                    return {
                        ok: true
                    };
                }

                return errorReturn();
            }
            catch{
                return errorReturn();
            }
        }
    },
    pets: {
        create: async (pet) => {
            let body = JSON.stringify({
                name: pet.name,
                breedId: pet.breed.id,
                petSizeId: pet.size.id,
                weightRangeId: pet.weightRange.id,
                birthDate: pet.birthDate,
                gender: pet.gender,
                sterilized: pet.sterilized,
                vaccinesUpToDate: pet.vaccinesUpToDate,
                preferedFood: pet.preferedFood,
                mealsPerDay: pet.mealsPerDay,
                vet: pet.vet.name ? {
                    name: pet.vet.name,
                    address: pet.vet.address,
                    phone: pet.vet.phone
                } : undefined
            });

            let response = await makeApiCall(Config.apiURLs.pets, "post", body);
            try {
                if (!response)
                    return errorReturn();

                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true
                    };
                }

                return errorReturn();
            }
            catch{
                return errorReturn();
            }
        },
        read: async (userid, maxExpectedCalories, maxCalories, minCalories, dateFrom, dateTo, timeFrom, timeTo, text, page, itemsPerPage) => {
            let body = JSON.stringify({
                "userId": userid,
                "maxExpectedCalories": maxExpectedCalories,
                "maxCalories": maxCalories,
                "minCalories": minCalories,
                "dateFrom": dateFrom ? dateFrom.toLocaleDateString() : dateFrom,
                "dateTo": dateTo ? dateTo.toLocaleDateString() : dateTo,
                "timeFrom": timeFrom ? timeFrom.toLocaleTimeString() : timeFrom,
                "timeTo": timeTo ? timeTo.toLocaleTimeString() : timeTo,
                "name": text,
                "page": page || 1,
                "itemsPerPage": itemsPerPage || 50
            });
            let response = await makeApiCall(Config.apiURLs.meals + '/search', "post", body);
            try {
                if (!response)
                    return errorReturn();

                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true,
                        meals: jsonResponse.result,
                        page: jsonResponse.page,
                        totalPages: jsonResponse.totalPages,
                        totalItems: jsonResponse.totalItems
                    };
                }

                return errorReturn();
            }
            catch{
                return errorReturn();
            }
        },
        getById: async (id) => {
            let response = await makeApiCall(Config.apiURLs.pets + '/' + id, "get");
            try {
                if (!response)
                    return errorReturn();

                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true,
                        result: jsonResponse
                    };
                }

                return errorReturn();
            }
            catch{
                return errorReturn();
            }
        },
        update: async (mealid, name, calories, dateTime) => {
            let body = JSON.stringify({ "name": name, "calories": calories, "dateTime": dateTime });
            let response = await makeApiCall(Config.apiURLs.meals + "/" + mealid, "put", body);

            let jsonResponse = await response.json();
            if (response.ok) {
                console.log(jsonResponse);
                return {
                    ok: true
                };
            }

            return {
                ok: false,
                errors: jsonResponse.errors
            }
        },
        delete: async (id) => {
            let response = await makeApiCall(Config.apiURLs.meals + "/" + id, "delete");

            if (response.ok) {
                return {
                    ok: true
                };
            }

            return {
                ok: false
            }
        }

    },
    services:{
        read: async () => {
            let response = await makeApiCall(Config.apiURLs.services, "get");

            try {
                if (!response) {
                    return errorReturn();
                }
                let jsonResponse = await response.json();
                if (response.ok) {
                    console.log(jsonResponse);
                    return {
                        ok: true,
                        result: jsonResponse
                    };
                }

                return errorReturn(jsonResponse.errors);
            }
            catch{
                return errorReturn();
            }
        },
    }
};
