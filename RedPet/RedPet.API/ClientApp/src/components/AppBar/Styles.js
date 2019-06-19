import { makeStyles } from '@material-ui/styles';

const Styles = makeStyles(theme => ({
   
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
        ...theme.mixins.toolbar
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
      nested: { paddingLeft: theme.spacing(4) }
}))

export default Styles;