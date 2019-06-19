import React from 'react';
import { Button } from '@material-ui/core';
import AlertDialogSlide from '../Common/AlertDialogSlide';
import { withRouter } from 'react-router-dom';

const NoPetsDialog = (props) => {

  const handleOk = () => {
    props.history.push('/pets/new')
  };
  const handleCancel = () => {
    props.toggle();
  };

  const actions =
    <div>
      <Button onClick={handleCancel} variant='contained' color="default">
        Cancelar
            </Button>
      <Button onClick={handleOk} variant='contained' color="secondary">
        Aceptar
            </Button>
    </div>

  return (
    <AlertDialogSlide isOpen={props.isOpen} toggle={props.toggle}
      title="Bienvenido a RedPet"
      content="Todavia no registro ninguna mascota, ¿Quiere ir a registrarlas ahora?"
      actions={actions}></AlertDialogSlide>
  );

}

export default withRouter(NoPetsDialog);