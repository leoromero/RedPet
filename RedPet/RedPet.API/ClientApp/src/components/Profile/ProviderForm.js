import React, { useState, useContext } from 'react';
import { Grid, TextField, FormControl, FormLabel, RadioGroup, FormControlLabel, FormHelperText, Radio } from '@material-ui/core';
import styles from '../../styles/styles';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { MessageContext } from '../../contexts/MessageContext';
import IdTypeSelect from '../Selects/IdTypeSelect';
import NationalitySelect from '../Selects/NationalitySelect';
import { NationalityModel, IdTypeModel } from '../../models/provider/provider';

const ProviderForm = (props) => {
  const {
    values,
    errors,
    touched,
    handleSubmit,
    handleChange,
    isValid,
    setFieldTouched,
    isNew,
    twoColumns
  } = props;

  const showMessage = useContext(MessageContext);
  const [idType, setIdType] = useState('');

  const classes = styles();

  const change = name => e => {
    e.persist();
    handleChange(e);
    setFieldTouched(name);

    if(name === 'identificationType')
      setIdType(e.currentTarget.textContent);
  }

  return (
    <form onSubmit={handleSubmit} id='providerForm'>
      <Grid container>
        <Grid item xs={12} container justify='center' className={classes.row}>
          <TextField
            name='address'
            label='Dirección'
            value={values.address? values.address : ''}
            onChange={change('address')}
            helperText={touched.address ? errors.address : ''}
            error={Boolean(touched.address && errors.address)}
          />
        </Grid>
        <Grid item container justify='center' className={classes.row}>
          <IdTypeSelect
            value={values.identificationType? values.identificationType.id : IdTypeModel.id}
            onChange={change('identificationType')}
            name='identificationType.id'
            id='identificationType.id'
            error={Boolean(touched.identificationType && errors.identificationType && errors.identificationType.id)}
            helperText={touched.identificationType && errors.identificationType && errors.identificationType.id} />
        </Grid>
        <Grid item item xs={12} container justify='center' className={classes.row}>
          <TextField
            name='identification'
            label={'Número ' + idType}
            value={values.identification? values.identification : ''}
            onChange={change('identification')}
            helperText={touched.identification ? errors.identification : ''}
            error={Boolean(touched.identification && errors.identification)}
          />
        </Grid>
        <Grid item container justify='center' className={classes.row}>
          <NationalitySelect
            value={values.nationality? values.nationality.id : NationalityModel.id}
            onChange={change('nationality')}
            name='nationality.id'
            id='nationality.id'
            error={Boolean(touched.nationality && errors.nationality && errors.nationality.id)}
            helperText={touched.nationality && errors.nationality && errors.nationality.id} />
        </Grid>
      </Grid>
    </form>
  )
}
export default ProviderForm;