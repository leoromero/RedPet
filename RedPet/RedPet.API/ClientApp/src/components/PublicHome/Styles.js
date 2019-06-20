import { makeStyles } from '@material-ui/styles';

const Styles = makeStyles(theme => ({
    hero: {
        minHeight: 380,
        backgroundColor: theme.palette.primary.main
    },
    secondary: {
        minHeight: 170,
    },
    content: {
        [theme.breakpoints.up('md')]: {
            paddingLeft: theme.spacing(10),
            paddingRight: theme.spacing(10),
        },
        paddingTop: theme.spacing(3),
        paddingBottom: theme.spacing(3)
    },
    grow: {
        flexGrow: 1,
    },
    title: {
        marginLeft: 10
    },
    appBar: {
        zIndex: theme.zIndex.drawer + 1,
        [theme.breakpoints.up('md')]: {
            paddingLeft: theme.spacing(5),
            paddingRight: theme.spacing(5),
        },
    },
    toolbar:{
        ...theme.mixins.toolbar
    },
    whiteText: {
        color: "#fff"
    },
    textAlignCenter:{
        textAlign:"center"
    },
  drawer: {
    width: 240,
    flexShrink: 0,
  },
  drawerPaper: {
    width: 240,
  },
}))

export default Styles;