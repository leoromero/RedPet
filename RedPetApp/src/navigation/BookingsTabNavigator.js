import React from 'react';
import { Platform } from 'react-native';
import { createStackNavigator, createMaterialTopTabNavigator, createBottomTabNavigator } from 'react-navigation';

import TabBarIcon from '../components/TabBarIcon';
import ServicesScreen from '../screens/bookings/services/ServicesScreen';
import ServiceDetailsScreen from '../screens/bookings/services/ServiceDetailsScreen';
import ProductsScreen from '../screens/bookings/products/ProductsScreen';
import ProductDetailsScreen from '../screens/bookings/products/ProductDetailsScreen';
import PromotionsScreen from '../screens/bookings/promotions/PromotionsScreen';
import PromotionDetailsScreen from '../screens/bookings/promotions/PromotionDetailsScreen';
import PetScreen from '../screens/profile/PetScreen';

const PromotionsStack = createStackNavigator({
  Promotions: PromotionsScreen,
  PromotionDetails: PromotionDetailsScreen
});

PromotionsStack.navigationOptions = {
  header: null,
  tabBarLabel: 'Promociones',
  tabBarIcon: ({ focused }) => (
    <TabBarIcon
      focused={focused}
      name={Platform.OS === 'ios' ? 'ios-link' : 'md-link'}
    />
  ),
};

const ProductsStack = createStackNavigator({
  Products: ProductsScreen,
  ProductDetails: ProductDetailsScreen
});

ProductsStack.navigationOptions = {
  header: null,
  tabBarLabel: 'Productos',
  tabBarIcon: ({ focused }) => (
    <TabBarIcon
      focused={focused}
      name={Platform.OS === 'ios' ? 'ios-link' : 'md-link'}
    />
  ),
};

const ServicesStack = createStackNavigator({
  Services: ServicesScreen,
  ServiceDetails: ServiceDetailsScreen,
  NewPet: PetScreen
},
{
  defaultNavigationOptions: {
  headerStyle: {
    // backgroundColor: 'black',
  },  
  headerTitleStyle: {
    fontWeight: 'bold',
    alignSelf: 'center',
    fontSize: 25
  },
}
});

ServicesStack.navigationOptions = {
  tabBarLabel: 'Servicios',
  tabBarIcon: ({ focused }) => (
    <TabBarIcon
      focused={focused}
      name={Platform.OS === 'ios' ? 'ios-options' : 'md-options'}
    />
  ),
};

export default createMaterialTopTabNavigator({
  PromotionsStack,
  ProductsStack,
  ServicesStack
},
{
  tabBarOptions:{
    labelStyle:{fontSize:12 },
    indicatorStyle:{
      backgroundColor: 'white',
    },
    style:{ 
      backgroundColor:'black',
    },
  }
}
);
