let apiBaseURL = "http://localhost:51445/api/";
export default {
    apiURLs:{
        login: apiBaseURL+"Auth",
        fbkLogin: apiBaseURL+"ExternalAuth/facebook",
        customers: apiBaseURL + "Customers",
        customers: apiBaseURL + "Providers",
        auth: apiBaseURL + "Auth",
        refreshToken: apiBaseURL + "Auth/Refresh",
        roles: apiBaseURL + "Roles",
        services: apiBaseURL + "Services",
        pets: apiBaseURL + "Pets",
        petSizes: apiBaseURL + "PetSizes",
        hairTypes: apiBaseURL + "HairTypes",
        weightRanges: apiBaseURL + "WeightRanges",
        breeds: apiBaseURL + "Breeds",
        users: apiBaseURL + "Users",
    }
};