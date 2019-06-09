export const breedModel = {
    name:'',
    id:''
};

export const sizeModel = {
    name:'',
    id:''
};

export const hairTypeModel = {
    name:'',
    id:''
};

export const weightRangeModel = {
    from:'',
    to:'',
    id:'',
    name:''
};

export const ownerModel = {
    name:'',
    id:''
};

export const vaccinationModel = {
    petId:'',
    vaccineId:'',
    id:''
};

export const vetModel = {
    name:'',
    address:'',
    phone:''
}
export const petModel = {
    name: '',
    breed: breedModel,
    petSize: sizeModel,
    hairType: hairTypeModel,
    weightRange: weightRangeModel,
    birthDate: null,
    gender: '',
    sterilized: false,
    observations: '',
    owner: ownerModel,
    id: '',
    vaccinations: [],
    mealsPerDay:'',
    preferedFood:'',
    vaccinesUpToDate:false,
    vet: vetModel
   };

export default {vaccinationModel, ownerModel, weightRangeModel, hairTypeModel, sizeModel, breedModel, petModel}