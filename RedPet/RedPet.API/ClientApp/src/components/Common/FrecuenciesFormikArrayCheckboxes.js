import React, { useState, useContext, useEffect } from 'react';
import { Grid, FormControl, FormHelperText, FormLabel, FormGroup, FormControlLabel, Checkbox, RadioGroup, Radio } from '@material-ui/core';
import styles from '../../styles/styles';
import { MessageContext } from '../../contexts/MessageContext';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';

const FrecuenciesFormikArrayCheckboxes = (props) => {
  const {
    push,
    remove,
    form
  } = props;

  const [frecuencies, setFrecuencies] = useState([]);
  const classes = styles();
  const showMessage = useContext(MessageContext);
  const frecuenciesIds = form.values.frecuencies ? form.values.frecuencies.map(f => f.id) : [];

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.parameters.frecuencies(), showMessage);

      if (apiResponse.ok) {
        setFrecuencies(apiResponse.result);
      }

    };
    apiCall();
  }, []);

  const change = (id, name) => e => {
    if (e.target.checked) push({ 'id': id, 'name': name });
    else {
      const idx = frecuenciesIds.indexOf(id);
      remove(idx);
    }
  };

  return (
    <FormControl
      error={props.error}
      component="fieldset"
    >
      <FormLabel className={classes.centerText} component="legend">{props.title}</FormLabel>
      <FormGroup row={props.row}>
        <Grid container justify="center">
          {frecuencies.map(frecuency =>
            <FormControlLabel
              key={frecuency.id}
              control={<Checkbox
                checked={frecuenciesIds.includes(frecuency.id)}
                name="frecuencies"
                onChange={change(frecuency.id, frecuency.name)}
                value={frecuency.name} />}
              label={frecuency.name}
              labelPlacement={props.labelPlacement}
            />
          )}
        </Grid>
      </FormGroup>
      {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
    </FormControl>
  );
};

export default FrecuenciesFormikArrayCheckboxes;