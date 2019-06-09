let apiBaseURL = "https://localhost:44360/api/";
export default {
    apiURLs:{
        login: apiBaseURL+"Auth",
        fbkLogin: apiBaseURL+"ExternalAuth/facebook",
        customers: apiBaseURL + "Customers",
        refreshToken: apiBaseURL + "Auth/Refresh",
        roles: apiBaseURL + "Roles",
        services: apiBaseURL + "Services",
        pets: apiBaseURL + "Pets",
        petSizes: apiBaseURL + "PetSizes",
        hairTypes: apiBaseURL + "HairTypes",
        weightRanges: apiBaseURL + "WeightRanges",
        breeds: apiBaseURL + "Breeds",
    }
};