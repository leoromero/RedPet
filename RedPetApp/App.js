import React from 'react';
import HybridApp from './src/App';
import { useScreens } from 'react-native-screens';
import {Container} from 'native-base';

useScreens();

export default class App extends React.Component {
  
  render() {
    return (
      <Container>
        <HybridApp/>
      </Container>
             );
    }   
};

