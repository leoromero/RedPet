import React, { useState, useContext, useEffect } from 'react';
import { Grid, FormControl, FormHelperText, FormLabel, FormGroup, FormControlLabel, Checkbox, RadioGroup, Radio } from '@material-ui/core';
import styles from '../../styles/styles';
import { MessageContext } from '../../contexts/MessageContext';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';

const FrecuencyRadioButtons = (props) => {
  const {
    values,
    errors,
    touched,
    handleSubmit,
    handleChange,
    isValid,
    setFieldTouched,
  } = props;

  const [frecuencies, setFrecuencies] = useState([]);
  const classes = styles();
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.parameters.frecuencies(), showMessage);

      if (apiResponse.ok) {
        setFrecuencies(apiResponse.result);
      }

    };
    apiCall();
  }, []);

  return (
    <FormControl error={props.error} component="fieldset">
      <FormLabel className={classes.centerText} component="legend" >{props.title}</FormLabel>

      <RadioGroup row
        aria-label={props.title ? props.title : "Frecuencia"}
        name={props.name ? props.name : "frecuency"}
        value={props.value}
        className={classes.row}
        onChange={props.onChange}
      >
        <Grid container justify="center">
          {
            frecuencies.map(f =>
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

export default FrecuencyRadioButtons;