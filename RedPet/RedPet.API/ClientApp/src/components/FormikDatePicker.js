import React from 'react';
import { DatePicker } from "@material-ui/pickers";
import { datePickerDefaultProps } from '@material-ui/pickers/constants/prop-types';

export const FormikDatePicker = ({
  form,
  field: { value, name },
  label,
  disableFuture,
  ...props
}) => {

  return (
    <>
      <DatePicker 
        name={name}
        keyboard
        label={label}
        format={"dd/MM/yyyy"}
        mask={value =>
          // handle clearing outside if value can be changed outside of the component
          value ? [/\d/, /\d/, "/", /\d/, /\d/, "/", /\d/, /\d/, /\d/, /\d/] : []
        }
        value={value}
        onBlur={value => {
          form.setFieldTouched(name);
          form.setFieldValue(name, value);
        }}
        onChange={value => {          
          form.setFieldTouched(name);
          form.setFieldValue(name, value);
        }}
        disableFuture= {disableFuture !== undefined ? disableFuture : true}
        disableOpenOnEnter
        animateYearScrolling={false}
        error={Boolean(form.touched[name] && form.errors[name])}
        helperText={Boolean(form.touched[name] && form.errors[name]) ? 'Introduzca una fecha valida.' : ''}
      />
    </>
  );
};

export default FormikDatePicker;