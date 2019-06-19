import * as Yup from 'yup';

const schema = Yup.object({
    username: Yup.string("Ingrese un nombre de usuario")
        .required("Ingrese un nombre de usuario"),
    password: Yup.string("Ingrese la contraseña")
        .required("Ingrese la contraseña"),
});

export default schema;