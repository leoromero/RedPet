
export const WeekDaysModel = {
    monday: false,
    tuesday: false,
    wednesday: false,
    thursday: false,
    friday: false,
    saturday: false,
    sunday: false,
};
export const FrecuencyModel = {};
export const ServiceTypeModel = {
    name: '',
    id: ''
};
export const ServiceModel = {
    id: '',
    serviceType: ServiceTypeModel,
    weekDays: WeekDaysModel,
    frecuencies: [],
    dailyPrice: 0,
    petSizes: [],
    subServices: []
};

export default { ServiceModel, ServiceTypeModel, WeekDaysModel, FrecuencyModel }