import React, { useContext, useState, useEffect } from 'react';
import { MessageContext } from '../../contexts/MessageContext';
import { Stepper, Step, StepLabel, Button, Card, Grid, Typography, withStyles, } from '@material-ui/core';
import BasicInfoForm from './BasicInfoForm';
import NutritionalInfo from './NutritionalInfo';
import MedicalInfo from './MedicalInfo';
import styles from '../../styles/styles';
import { Formik } from 'formik';
import { petModel } from '../../models/pet/pet';
import petValidation from '../../validations/petValidation';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';

const PetForm = (props) => {
  const showMessage = useContext(MessageContext);
  const classes = styles();
  const [activeStep, setActiveStep] = useState(0);
  const steps = ['Datos Básicos', 'Datos Nutricionales', 'Datos Médicos'];
  const [pet, setPet] = useState(undefined);

  useEffect(() => {
    if (props.petId) {
      const apiCall = async () => {
        const apiResponse = await useApi(Api.pets.getById(props.petId), showMessage);

        if (apiResponse.ok) {
          setPet(apiResponse.result);
        }
      };

      apiCall();
    }
  }, []);

  const getLastStep = () => steps.length - 1;

  const handleBack = () => {
    if (activeStep !== '0') setActiveStep(activeStep - 1);
  };

  const handleNext = (pet) => {
    setActiveStep(activeStep + 1);
    if (activeStep === getLastStep()) {
      submitForm(pet);
    }
  }

  const submitForm = async pet => {
    const apiResponse = await useApi(Api.pets.create(pet), showMessage);
  }

  const getStepContent = (petToEdit) => {
    switch (activeStep) {
      case 0:
        return (
          <Formik enableReinitialize initialValues={petToEdit} validationSchema={petValidation} onSubmit={handleNext} component={BasicInfoForm} />
        );
      case 1:
        return (
          <Formik enableReinitialize initialValues={petToEdit} onSubmit={handleNext} component={NutritionalInfo} />
        );
      case 2:
        return (
          <Formik enableReinitialize initialValues={petToEdit} onSubmit={handleNext} component={MedicalInfo} />
        );
    }
  }
  return (
    <>
      <Typography align='center' variant='h6'>Registrar nueva mascota</Typography>
      <Stepper activeStep={activeStep} >
        {
          steps.map((label, index) => (
            <Step key={index}>
              <StepLabel>{label}</StepLabel>
            </Step>
          ))
        }
      </Stepper>
      <Grid container spacing={24} justify='center'>
        <Grid item xs={12} >
          {getStepContent(pet ? pet : petModel)}
        </Grid>

        <Grid item className={classes.formControl}>
          <Button
            variant='contained'
            disabled={activeStep === 0}
            onClick={handleBack}
          >
            Back
                </Button>
          <Button
            type='submit'
            form={'step-' + activeStep + '-form'}
            variant="contained"
            color="secondary"
          >
            {activeStep === getLastStep() ? 'Finish' : 'Next'}
          </Button>
        </Grid>
      </Grid>
    </>
  );
};

export default PetForm;