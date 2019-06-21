import React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@material-ui/core/AppBar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';
import Styles from './Styles';
import UserInformation from './UserInformation';
import ProviderInformation from './ProviderInformation';
import PaymentInformation from './PaymentInformation';

const TabContainer = (props) => 
    <Typography component="div" style={{ padding: 8 * 3 }}>
      {props.children}
    </Typography>


TabContainer.propTypes = {
  children: PropTypes.node.isRequired,
};



const Profile = () => {
  const classes = Styles();
  const [value, setValue] = React.useState(0);

  function handleChange(event, newValue) {
    setValue(newValue);
  }

  return (
    <div className={classes.root}>
      <AppBar position="static" color="default">
        <Tabs
          value={value}
          onChange={handleChange}
          indicatorColor="primary"
          textColor="primary"
          variant="scrollable"
          scrollButtons="auto"
        >
          <Tab label="Usuario" />
          <Tab label="Cuidador" />
          <Tab label="Pagos" />
        </Tabs>
      </AppBar>
      {value === 0 && <TabContainer><UserInformation /></TabContainer>}
      {value === 1 && <TabContainer><ProviderInformation /></TabContainer>}
      {value === 2 && <TabContainer><PaymentInformation /></TabContainer>}
    </div>
  );
}

export default Profile;