import { makeStyles } from '@material-ui/styles';

const styles = makeStyles(theme => ({
  row: {
    margin: theme.spacing(1),
  },

  formControl: {
    margin: theme.spacing(1),
    maxWidth: 195,
    width: 195
  },
  page: {
    flexGrow: 1,
    minHeight: '100%'
  },
  main: {
    display: 'flex',
    flex: 1
  },
  mainAuthenticated: {
    display: 'flex',
    flexGrow: 1,
    [theme.breakpoints.up('md')]: {
      width: 'calc(100% - 240px)',
      marginLeft: '240px'
    },
  },
  content: {
    flex: 1,
    [theme.breakpoints.up('md')]: {
      padding: theme.spacing(3)
    }
  },
  contentWithoutPadding: {
    flex: 1,
  },
  fab: {
    position: 'absolute',
    bottom: theme.spacing(3),
    right: theme.spacing(3)
  },
  circularProgress: {
    position: 'absolute',
    top: '50%',
    left: '50%',
    marginTop: -12,
    marginLeft: -12,
  }
}))

export default styles;