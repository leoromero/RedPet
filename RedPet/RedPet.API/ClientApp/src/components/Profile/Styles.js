import { makeStyles } from '@material-ui/styles';

const Styles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
    width: '100%',
  },
  page: {
    flexGrow: 1,
    minHeight: '100%'
  },
  content: {
    flex: 1,
    [theme.breakpoints.up('md')]: {
      padding: theme.spacing(3)
    }
  },
}))

export default Styles;