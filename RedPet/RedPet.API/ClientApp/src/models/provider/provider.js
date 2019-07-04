
export const NationalityModel = {
    nation: '',
    code: '',
    id: ''
};
export const IdTypeModel = {
    name: '',
    id: ''
};
export const ProviderModel = {
    id: '',
    services: '',
    gender: '',
    firstName: '',
    lastName: '',
    facebookId: '',
    email: '',
    userName: '',
    userId: '',
    identificationType: IdTypeModel,
    identification: '',
    nationality: NationalityModel,
    address: '',
    name: '',
};

export default { ProviderModel, IdTypeModel, NationalityModel }