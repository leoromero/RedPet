import React, { useContext, useState } from 'react';
import { MessageContext } from '../../contexts/MessageContext';
import { Grid, TextField } from '@material-ui/core';

const NutritionalInfo = (props) => {
    const showMessage = useContext(MessageContext);
    const [name, setName] = useState('');
    const {
      values,
      errors,
      touched,
      handleSubmit,
      handleChange,
      isValid,
      setFieldTouched
      } = props;

    return( 
      <form onSubmit={handleSubmit} id='step-1-form'>
      <Grid container>
        <Grid container justify='center'>
          <Grid item>
            <TextField 
            label='Comida'
            name='preferedFood'
            value={values.preferedFood}
            onChange={handleChange}
            />
          </Grid>
        </Grid>
        <Grid container justify='center'>
          <Grid item>
            <TextField 
            label='Cantidad de comidas al día'
            value={values.mealsPerDay}
            name='mealsPerDay'
            onChange={handleChange}
            />
          </Grid>
        </Grid>       
      </Grid>
      </form>
      );
};
  
  export default NutritionalInfo;