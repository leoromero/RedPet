import { makeStyles } from '@material-ui/styles';

const Styles = makeStyles(theme => ({
    root: {
        display: 'flex',
      },
      grow: {
        flexGrow: 1,
      },
      title: {
        marginLeft: 10
      },
      appBar: {
        zIndex: theme.zIndex.drawer + 1,
        paddingLeft: theme.spacing(5),
        paddingRight: theme.spacing(5),
      },
      drawer: {
        width: 240,
        flexShrink: 0,
      },
      drawerPaper: {
        width: 240,
      },
      content: {
        flexGrow: 1,
        padding: theme.spacing(3),
      },
      toolbar: theme.mixins.toolbar,
      nested: { paddingLeft: theme.spacing.unit * 4 }
}))

export default Styles;