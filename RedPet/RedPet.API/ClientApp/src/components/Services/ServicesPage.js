import React, { useContext, useState, useEffect } from 'react';
import { Card, Grid, Fab, Typography, AppBar, Tabs, Tab } from '@material-ui/core';
import PetForm from './ServiceForm';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { Redirect } from 'react-router-dom';
import { Add as AddIcon } from '@material-ui/icons';
import { withRouter } from 'react-router-dom';
import { MessageContext } from '../../contexts/MessageContext';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { isNullOrUndefined } from 'util';
import ServiceCard from './ServiceCard';
import { DayCareIcon } from '../icons/DayCareIcon';

const ServicesPage = (props) => {
  const classes = styles();
  const { user } = useContext(AuthContext);
  const showMessage = useContext(MessageContext);
  const [services, setServices] = useState(undefined);
  const [serviceTypes, setServiceTypes] = useState(undefined);
  const [tabValue, setTabValue] = React.useState(1);

  useEffect(() => {
    const servicesApiCall = async () => {

      const apiResponse = await useApi(Api.services.read(), showMessage);

      if (apiResponse.ok) {
        setServices(apiResponse.result);
      }
    };
    const serviceTypesApiCall = async () => {
      
      const apiResponse = await useApi(Api.parameters.serviceTypes(), showMessage);

      if (apiResponse.ok) {
        setServiceTypes(apiResponse.result);
      }
    };

    servicesApiCall();
    serviceTypesApiCall();
  }, []);

  const handleAdd = () => {
    props.history.push('/service/new');
  };

  function handleChange(event, newValue) {
    setTabValue(newValue);
  }

  if (services === undefined) return null;

  const servicesInType = services.filter(x => x.serviceType === tabValue);

  return (
    <Grid container direction="column" className={classes.page} >
      <div className={classes.toolbar}>
        <AppBar position="static">
          <Tabs
            value={tabValue}
            onChange={handleChange}
            variant="fullWidth">
            {
              serviceTypes &&
              serviceTypes.map((type, i) =>
                <Tab key={i} value={type.id} label={type.name} />
              )}
          </Tabs>
        </AppBar>
      </div>
      {
        servicesInType.length > 0 ?
          servicesInType.map((service) =>
            <Grid item xs={12} md={6} lg={4}>
              <ServiceCard id={service.id} serviceType={service.serviceType} serviceIcon={<DayCareIcon />} />
            </Grid>
          ) :
          <Typography variant='subtitle1'>Todavía no te has registrado para trabajar con {serviceTypes && serviceTypes.filter(x => x.id == tabValue)[0].name.toLowerCase()}.</Typography>
      }
      <Fab color="secondary" aria-label="Add" className={classes.fab} onClick={handleAdd}>
        <AddIcon />
      </Fab>
    </Grid>
  );
};

export default withRouter(ServicesPage);