import { useState, useContext } from 'react'
import rules from "../config/authRules";
import { AuthContext } from '../contexts/AuthContext';

const check = (rules, role, action, data) => {
  const permissions = rules[role];
  if (!permissions) {
    // role is not present in the rules
    return false;
  }

  const staticPermissions = permissions.static;

  if (staticPermissions && staticPermissions.includes(action)) {
    // static rule not provided for action
    return true;
  }

  const dynamicPermissions = permissions.dynamic;

  if (dynamicPermissions) {
    const permissionCondition = dynamicPermissions[action];
    if (!permissionCondition) {
      // dynamic rule not provided for action
      return false;
    }

    return permissionCondition(data);
  }
  return false;
};

const useCan = (action, data) => {
    
    const { user } = useContext(AuthContext);
    
    return check(rules, user.role, action, data);
}

export default useCan;