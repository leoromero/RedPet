import * as Yup from 'yup';

const schema = Yup.object({
    name: Yup.string("Ingrese un nombre")
        .required("El nombre es obligatorio"),
    lastName: Yup.string("Ingrese el apellido")
        .required("El apellido es obligatorio"),
    email: Yup.string("Ingrese el email")
        .email('El email ingresado no es valido.')
        .required("El email es obligatorio"),
    gender: Yup.string('Elija el sexo')
        .required('Elija el sexo'),
    identification: Yup.string("Ingrese el número.").nullable()
        .required("El número es obligatorio"),
    address: Yup.string("Ingrese la dirección.").nullable()
    .required("La dirección es obligatoria"),
    identificationType: Yup.object().noUnknown(true,"Seleccione el tipo de identificación").shape({
        id: Yup.number("Seleccione el tipo de identificación").moreThan(0,'Seleccione el tipo de identificación')
            .required("El tipo de identificación es obligatorio")
    }),
    nationality: Yup.object().noUnknown(true,"Seleccione la nacionalidad").shape({
        id: Yup.number("Seleccione la nacionalidad").moreThan(0,'Seleccione la nacionalidad')
            .required("La nacionalidad es obligatoria")
    }),
});

export default schema;