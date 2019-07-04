import * as Yup from 'yup';

const schema = Yup.object({
    firstName: Yup.string("Ingrese un nombre")
        .required("El nombre es obligatorio"),
    lastName: Yup.string("Ingrese el apellido")
        .required("El apellido es obligatorio"),
    email: Yup.string("Ingrese el email")
        .email('El email ingresado no es valido.')
        .required("El email es obligatorio"),
    password: Yup.string("Ingrese la contraseña")
        .required('La contraseña es obligatoria'),
    password2: Yup.string('Repita la contraseña')
        .oneOf([Yup.ref('password'), null], 'Las contraseñas tienen que coincidir'),
    gender: Yup.string('Elija el sexo')
        .required('Elija el sexo'),
});

export default schema;