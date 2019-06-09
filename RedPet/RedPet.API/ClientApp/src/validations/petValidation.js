import * as Yup from 'yup';

const schema = Yup.object({
    name: Yup.string("Ingrese un nombre")
    .required("El nombre es obligatorio"),
    breed: Yup.object().shape({
        id: Yup.string("Ingrese la raza")
        .required("La raza es obligatoria")}),
    birthDate: Yup.date("Ingrese la fecha de nacimiento")
    .required('La fecha de nacimiento es obligatoria')
    ,
    gender: Yup.string('Elija el sexo')
    .required('Elija el sexo'),
    petSize: Yup.object().shape({
        id: Yup.string().required('El tamaño es obligatorio')}),
    });

export default schema;