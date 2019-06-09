import React, { useEffect, useContext, useState } from 'react';
import { Grid, Button } from '@material-ui/core';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';
import { MessageContext } from '../../contexts/MessageContext';
import AlertDialogSlide from '../Common/AlertDialogSlide';
import useOpen from '../../Hooks/useOpen';
import NoPetsDialog from './NoPetsDialog';

const HomePage = (props) => {
  const classes = styles();
  const { user } = useContext(AuthContext);
  const showMessage = useContext(MessageContext);
  const [pets, setPets] = useState([]);
  const { isOpen: showNoPetsModal, toggle: toggleShowNoPetsModal } = useOpen();

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.customers.pets(user.id), showMessage);

      if (apiResponse.ok) {
        apiResponse.result.length > 0 ?
          setPets(apiResponse.result)
          : toggleShowNoPetsModal();
      }
    };

    apiCall();
  }, []);

  return (
    <Grid container className={classes.page}>
      <Grid item xs={12} md={12}>
        <NoPetsDialog isOpen={showNoPetsModal} toggle={toggleShowNoPetsModal} />
      </Grid>
    </Grid>
  );

}

export default HomePage;