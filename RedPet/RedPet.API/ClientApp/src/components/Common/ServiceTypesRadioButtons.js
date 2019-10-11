import React, { useState, useContext, useEffect } from 'react';
import { Grid, FormControl, FormHelperText, FormLabel, FormGroup, FormControlLabel, Checkbox, RadioGroup, Radio } from '@material-ui/core';
import styles from '../../styles/styles';
import { MessageContext } from '../../contexts/MessageContext';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';

const ServiceTypesRadioButtons = (props) => {
  const {
    values,
    errors,
    touched,
    handleSubmit,
    handleChange,
    isValid,
    setFieldTouched,
  } = props;

  const [serviceTypes, setServiceTypes] = useState([]);
  const classes = styles();
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.parameters.serviceTypes(), showMessage);

      if (apiResponse.ok) {
        setServiceTypes(apiResponse.result);
      }

    };
    apiCall();
  }, []);

  return (
    <FormControl error={props.error} component="fieldset">
      <FormLabel className={classes.centerText} component="legend" >{props.title}</FormLabel>

      <RadioGroup row
        aria-label={props.title ? props.title : "Servicio"}
        name={props.name ? props.name : "serviceType"}
        value={props.value}
        className={classes.row}
        onChange={props.onChange}
      >
        <Grid container justify="center">
          {
            serviceTypes.map(f =>
              <FormControlLabel
                key={f.id}
                value={f.id}
                control={<Radio checked={props.value == f.id} />}
                label={f.name}
                labelPlacement={props.labelPlacement}
              />
            )
          }
        </Grid>
      </RadioGroup>
    </FormControl >
  );
};

export default ServiceTypesRadioButtons;