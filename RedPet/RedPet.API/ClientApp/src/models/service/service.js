
export const WeekDaysModel = {
    monday: false,
    tuesday: false,
    wednesday: false,
    thursday: false,
    friday: false,
    saturday: false,
    sunday: false,
};
export const FrecuencyModel = {
    name:'',
    id:''
};
export const ServiceTypeModel = {
    name: '',
    id: ''
};
export const ServiceModel = {
    id: '',
    serviceType: ServiceTypeModel,
    weekDays: WeekDaysModel,
    frecuencies: [],
    price: 0,
    petSizes: [],
    subServices: [],
    userId: 0
};

export default { ServiceModel, ServiceTypeModel, WeekDaysModel, FrecuencyModel }