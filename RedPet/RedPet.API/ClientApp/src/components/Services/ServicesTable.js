import React from 'react';
import { Card, Grid, Typography, Fab, Table, TableCell, TableRow, TableHead, TableBody } from '@material-ui/core';
import { Edit } from '@material-ui/icons';
import { makeStyles } from '@material-ui/styles';
import { withRouter } from 'react-router-dom';

const ServicesTable = (props) => {
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
    <Table>
      <TableHead>
        <TableRow>
          <TableCell>Nombre</TableCell>
          <TableCell>Precio</TableCell>
          <TableCell>Dias</TableCell>
          <TableCell>Tamaños</TableCell>
          <TableCell>Frecuencia</TableCell>
          <TableCell>Editar</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {props.services && props.services.map(row => (
          <TableRow key={row.id}>
            <TableCell>{row.name}</TableCell>
            <TableCell>{row.price}</TableCell>
            <TableCell>
              {row.weekDays.monday && 'L '}
              {row.weekDays.tuesday && 'Ma '}
              {row.weekDays.wednesday && 'Mi '}
              {row.weekDays.thursday && 'J '}
              {row.weekDays.friday && 'V '}
              {row.weekDays.saturday && 'S '}
              {row.weekDays.sunday && 'D'}
            </TableCell>
            <TableCell>{row.petSizes.map(s => s.name + ' ')}</TableCell>
            <TableCell>{row.frecuencies.map(s => s.name + ' ')}</TableCell>
            <TableCell>editar - borrar</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};

export default withRouter(ServicesTable);