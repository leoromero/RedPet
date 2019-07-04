import React from 'react';
import { Card, Grid, Typography, Fab } from '@material-ui/core';
import { Edit } from '@material-ui/icons';
import { makeStyles } from '@material-ui/styles';
import { withRouter } from 'react-router-dom';

const ServiceCard = (props) => {
  const styles = makeStyles(theme => ({
    fab: {
      bottom: theme.spacing(1),
      right: theme.spacing(1)
    }
  }));
  const classes = styles();

  const handleEdit = () => {
    props.history.push('/service/' + props.id)
  };
  return (
    <Card>
      <Grid container>
        <Grid container alignContent="center" justify="center" item xs={3}>
          {props.serviceIcon}
        </Grid>
        <Grid container alignContent="center" justify="center" item xs={6}>
          <Typography variant='h5'>{props.serviceType.name}</Typography>
        </Grid>
        <Grid container item xs={3} justify='flex-end'>
          <Fab color="primary" aria-label="Edit" className={classes.fab} onClick={handleEdit}>
            <Edit />
          </Fab>
        </Grid>
      </Grid>
    </Card>
  );
};

export default withRouter(ServiceCard);