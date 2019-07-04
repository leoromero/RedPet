import React, { useState, useContext, useEffect } from 'react';
import { Grid, FormControl, FormHelperText, FormLabel, FormGroup, FormControlLabel, Checkbox } from '@material-ui/core';
import styles from '../../styles/styles';
import { MessageContext } from '../../contexts/MessageContext';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';

const PetSizesFormikArrayCheckboxes = (props) => {
  const {
    push,
    remove,
    form
  } = props;
  const [petSizes, setPetSizes] = useState([]);
  const classes = styles();
  const showMessage = useContext(MessageContext);

  const petSizesIds = form.values.petSizes ? form.values.petSizes.map(ps => ps.id) : [];

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.parameters.petSizes(), showMessage);

      if (apiResponse.ok) {
        setPetSizes(apiResponse.result);
      }

    };
    apiCall();
  }, []);


  const change = (id, name) => e => {
    if (e.target.checked) push({ 'id': id, 'name': name });
    else {
      const idx = petSizesIds.indexOf(id);
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
          {petSizes.map(petsize =>
            <FormControlLabel
              key={petsize.id}
              control={<Checkbox
                checked={petSizesIds.includes(petsize.id)}
                name="petSizes"
                onChange={change(petsize.id, petsize.name)}
                value={petsize.name} />}
              label={petsize.name}
              labelPlacement={props.labelPlacement}
            />
          )}
        </Grid>
      </FormGroup>
      {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
    </FormControl>
  );
};

export default PetSizesFormikArrayCheckboxes;