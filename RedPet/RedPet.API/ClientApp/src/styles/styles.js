import { makeStyles } from '@material-ui/styles';

const styles = makeStyles(theme => ({
  row: {
    margin: theme.spacing.unit,
    display: 'flex',
    flexDirection: 'row'
  },

  formControl: {
    margin: theme.spacing.unit,
    maxWidth: 195,
    width: 195
  },
  page: {
    height: '100%'
  },
  main: {
    flexGrow: 1,
    [theme.breakpoints.up('md')]: {
      width: 'calc(100% - 240px)',
      marginLeft: '240px'
    },    
  },
  content: {
    padding: theme.spacing.unit * 3      
  },
  toolbar: theme.mixins.toolbar,
  fab:{
    position:'absolute',
    bottom: theme.spacing.unit * 3,
    right: theme.spacing.unit * 3 
  }
}))

export default styles;