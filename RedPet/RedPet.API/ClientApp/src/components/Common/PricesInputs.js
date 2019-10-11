import React, { useState, useContext, useEffect } from 'react';
import { Grid, FormControl, FormHelperText, FormLabel, FormGroup, FormControlLabel, Checkbox, TextField } from '@material-ui/core';
import styles from '../../styles/styles';
import { MessageContext } from '../../contexts/MessageContext';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';

const PricesInputs = (props) => {

  const classes = styles();
  const showMessage = useContext(MessageContext);
  const [daily, setDaily] = useState(props.value ? props.value : '');
  const [weekly, setWeekly] = useState(props.value ? props.value * 5 : '');
  const [monthly, setMonthly] = useState(props.value ? props.value * 22 : '');
  const [frecuencies, setFrecuencies] = useState([]);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.parameters.frecuencies(), showMessage);

      if (apiResponse.ok) {
        setFrecuencies(apiResponse.result);
      }

    };
    apiCall();
  }, []);
  const changePrice = e => {
    e.persist();
    let price = e.currentTarget.value;
    let priceType = e.currentTarget.name;
    let weekly = 0;
    let monthly = 0;

    if (price) {
      switch (priceType) {
        case 'daily':
          weekly = price * 5;
          monthly = price * 22;
          break;
        case 'weekly':
          weekly = price;
          price = price / 5;
          monthly = price * 22;
          break;
        case 'monthly':
          monthly = price;
          price = price / 22;
          weekly = price * 5;
          break;
      }

      price = Math.round(price * 100) / 100;
      weekly = Math.round(weekly * 100) / 100;
      monthly = Math.round(monthly * 100) / 100;

      setDaily(price);
      setWeekly(weekly);
      setMonthly(monthly);
      props.onChange(price);
    }
  }

  return (
    <FormControl error={props.error} component="fieldset">
      <FormLabel className={classes.centerText} component="legend" >{props.title}</FormLabel>
      <FormGroup row >
        <Grid item container justify="center">
          <Grid item xs={3} container justify='center'>
            <TextField
              type="number"
              name='daily'
              label='Diario'
              value={daily}
              onChange={(e) => setDaily(e.currentTarget.value)}
              onBlur={changePrice}
            />
          </Grid>
          {props.frecuencies.some(x => frecuencies && frecuencies.some(f => f.name == 'Semanal')) &&
            <Grid item xs={3} container justify='center'>
              <TextField
                name='weekly'
                label='Semanal'
                value={weekly}
                onChange={(e) => setWeekly(e.currentTarget.value)}
                onBlur={changePrice}
              />
            </Grid>
          }
          {props.frecuencies.some(x => frecuencies && frecuencies.some(f => f.name == 'Mensual')) &&
            <Grid item xs={3} container justify='center'>
              <TextField
                name='monthly'
                label='Mensual'
                value={monthly}
                onChange={(e) => setMonthly(e.currentTarget.value)}
                onBlur={changePrice}
              />
            </Grid>
          }
        </Grid>
      </FormGroup>
      <Grid item container justify="center">
        {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
      </Grid>
    </FormControl>
  );
};

export default PricesInputs;