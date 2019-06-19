import React from 'react';
import { Card, Grid, Typography, Fab } from '@material-ui/core';
import { Edit } from '@material-ui/icons';
import { makeStyles } from '@material-ui/styles';
import { withRouter } from 'react-router-dom';

const PetCard = (props) => {
  const styles = makeStyles(theme => ({
    fab: {
      bottom: theme.spacing(1),
      right: theme.spacing(1)
    }
  }));
  const classes = styles();
  const birthDate = new Date(props.birthDate);

  const handleEdit = () => {
    props.history.push('/pet/' + props.id )
   };
  return (
    <Card>
      <Grid container>
        <Grid item xs={6}>
          {/* imagen 150 * 150 */}
        </Grid>
        <Grid item xs={6}>
          <Grid container direction='column'>
            <Typography variant='subtitle1'>{props.name}</Typography>
            <Typography>{'Nacimiento: ' + birthDate.toLocaleDateString()}</Typography>
            <Typography >{'Raza: ' + props.breed}</Typography>
            <Typography >{'Sexo: ' + (props.gender === 'f' ? 'Hembra' : 'Macho')}</Typography>
          </Grid>
          <Grid container direction='row' justify='flex-end'>
            <Grid item>
              <Fab color="primary" aria-label="Edit" className={classes.fab} onClick={handleEdit}>
                <Edit />
              </Fab>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Card>
  );
};

export default withRouter(PetCard);