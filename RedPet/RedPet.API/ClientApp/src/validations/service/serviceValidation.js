import * as Yup from 'yup';

const schema = Yup.object({
    serviceType: Yup.object().noUnknown(true,"Seleccione el servicio").shape({
        id: Yup.number("Seleccione el servicio").moreThan(0,'Seleccione el servicio')
            .required("El servicio es obligatorio")
    }),    
    weekDays: Yup.object({
      monday: Yup.boolean(),
      tuesday: Yup.boolean(),
      wednesday: Yup.boolean(),
      thursday: Yup.boolean(),
      friday: Yup.boolean(),
      saturday: Yup.boolean(),
      sunday: Yup.boolean()
    }).test(
      'weekDays',
      null,
      (obj) => {
        if ( obj.monday || obj.tuesday || obj.wednesday 
            || obj.thursday || obj.friday || obj.saturday || obj.sunday) {
          return true; // everything is fine
        }
  
        return new Yup.ValidationError(
          'Debes seleccionar al menos un día.',
          null,
          'weekDays'
        );
      }
    )
});

export default schema;