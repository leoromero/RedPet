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

    AuthHelper.logout();
    return false;
};
const errorReturn = (response) => {
    if (response && response.errors) {
        return {
            status: response.status,
            ok: false,
            errors: response.errors
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
        frecuencies: async () => {
            let response = await makeApiCall(Config.apiURLs.frecuencies, "get");
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
                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        nationalities: async () => {
            let response = await makeApiCall(Config.apiURLs.nationalities, "get");
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
                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        serviceTypes: async () => {
            let response = await makeApiCall(Config.apiURLs.serviceTypes, "get");
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
                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        idTypes: async () => {
            let response = await makeApiCall(Config.apiURLs.idTypes, "get");
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
                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
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
                return errorReturn(jsonResponse);
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
                return errorReturn(jsonResponse);
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

                return errorReturn(jsonResponse);
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

                return errorReturn(jsonResponse);
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
            return errorReturn(jsonResponse);
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

                    return errorReturn(jsonResponse);
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

            return errorReturn(jsonResponse);
        }
        catch{
            return errorReturn();
        }
    },
    users: {
        validateEmail: async (email) => {
            let response = await makeApiCall(Config.apiURLs.users + '/email/' + email, "head");

            try {
                if (!response) {
                    return errorReturn();
                }

                return {
                    ok: response.ok,
                    status: response.status
                };
            }
            catch{
                return errorReturn();
            }
        },
        create: async (user) => {
            let body = JSON.stringify({ "email": user.email, "password": user.password, "firstName": user.name, "lastName": user.lastName, "gender": user.gender, "role": user.role });

            let response = await makeApiCall(Config.apiURLs.users, "post", body);

            try {
                if (!response) {
                    return errorReturn();
                }

                let jsonResponse = await response.json();
                if (response.ok) {
                    return {
                        ok: true,
                        result: {
                            id: jsonResponse
                        }
                    };
                }
                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        update: async (user) => {
            let body = JSON.stringify({ "email": user.email, "firstName": user.name, "lastName": user.lastName, "gender": user.gender });

            let response = await makeApiCall(Config.apiURLs.users, "put", body);

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
                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        getById: async (id) => {
            let response = await makeApiCall(Config.apiURLs.users + '/' + id, "get");

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

                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
    },
    customers: {
        pets: async (userid) => {
            let response = await makeApiCall(Config.apiURLs.customers + '/' + userid + '/pets', "get");
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


                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        create: async (user) => {
            let body = JSON.stringify({ "email": user.email, "password": user.password, "firstName": user.firstName, "lastName": user.lastName, "gender": user.gender, "role": user.role });
            let response = await makeApiCall(Config.apiURLs.customers, "post", body);

            try {
                if (!response) {
                    return errorReturn();
                }

                let jsonResponse = await response.json();
                if (response.ok) {
                    return {
                        ok: true,
                        result: {
                            id: jsonResponse
                        }
                    };
                }
                return errorReturn(jsonResponse);
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

                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        getByUsername: async (username) => {
            let response = await makeApiCall(Config.apiURLs.customers + '/' + username, "get");

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

                return errorReturn(jsonResponse);
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

                return errorReturn(jsonResponse);
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
    providers: {
        create: async (user) => {
            let body = JSON.stringify({
                "email": user.email,
                "password": user.password,
                "firstName": user.firstName,
                "lastName": user.lastName,
                "gender": user.gender
            });
            let response = await makeApiCall(Config.apiURLs.providers, "post", body);

            try {
                if (!response) {
                    return errorReturn();
                }

                let jsonResponse = await response.json();
                if (response.ok) {
                    return {
                        ok: true,
                        result: {
                            id: jsonResponse
                        }
                    };
                }
                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        update: async (user) => {
            let body = JSON.stringify({
                "nationalityId": user.nationality.id,
                "identification": user.identification,
                "identificationTypeId": user.identificationType.id,
                "email": user.email,
                "firstName": user.firstName,
                "lastName": user.lastName,
                "gender": user.gender,
                'address': user.address
            });
            let response = await makeApiCall(Config.apiURLs.providers + '/' + user.id, "put", body);

            try {
                if (!response) {
                    return errorReturn();
                }

                let jsonResponse = await response.json();
                if (response.ok) {
                    return {
                        ok: true,
                        result: {
                            id: jsonResponse
                        }
                    };
                }
                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        getByUsername: async (username) => {
            let response = await makeApiCall(Config.apiURLs.providers + '/' + username, "get");

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

                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
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
    services: {
        create: async (service, userid) => {
            let body = JSON.stringify({
                serviceTypeId: service.serviceType.id,
                weekDays: service.weekDays,
                userId: userid,
                price: service.price,
                frecuencies: service.frecuencies,
                petSizes: service.petSizes,
                serviceSubTypes: service.subServices,
            });

            let response = await makeApiCall(Config.apiURLs.services, "post", body);
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

                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
        getById: async (serviceId) => {
            let response = await makeApiCall(Config.apiURLs.services + '/' + serviceId, "get");

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

                return errorReturn(jsonResponse);
            }
            catch{
                return errorReturn();
            }
        },
    }
};
