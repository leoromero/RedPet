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
      <Button onClick={handleCancel} color="primary">
        Cancelar
            </Button>
      <Button onClick={handleOk} color="primary">
        Aceptar
            </Button>
    </div>

  return (
    <AlertDialogSlide isOpen={props.isOpen} toggle={props.toggle}
      title="Bienvenido a RedPet"
      content="Todavia no registro ninguna mascota, ¿Quiere ir a registrarlas ahora?"
      actions={actions} />
  );

}

export default withRouter(NoPetsDialog);