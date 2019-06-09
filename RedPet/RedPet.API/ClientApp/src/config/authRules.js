const rules = {
  Visitor: {
    static: [
      "homepage:visit",
      "homepage:login",
      "users:create"
    ]
  },
  Admin: {
    static: [
      "service:create",
      "service:read",
      "service:update",
      "service:delete",
      "users:create",
      "users:read",
      "users:update",
      "users:delete",
      "roles:read"
    ],
    dynamic: {
      "users:updatePassword": ({userId, userToEditId}) => {
        if (!userId || !userToEditId) return false;
        return userId === userToEditId;
      }
    }
  },
  Customer: {
    static: [
      "booking:create",
      "service:read"
    ],
    dynamic: {
      "booking:update": ({userId, bookingUserId}) => {

        if (!userId || !bookingUserId) return false;
        return userId == bookingUserId;
      },
      "booking:cancel": ({userId, bookingUserId}) => {
        if (!userId || !bookingUserId) return false;
        return userId == bookingUserId;
      },
      "users:update": ({userId, userToEditId}) => {
        if (!userId || !userToEditId) return false;
        return userId == userToEditId;
      },
      "users:updatePassword": ({userId, userToEditId}) => {
        if (!userId || !userToEditId) return false;
        return userId == userToEditId;
      }
    }
  },
  Provider: {
    static: [
      "roles:read"
    ],
    dynamic: {
      "booking:update": ({userId, bookingProviderId}) => {

        if (!userId || !bookingProviderId) return false;
        return userId == bookingProviderId;
      },
      "booking:cancel": ({userId, bookingProviderId}) => {
        if (!userId || !bookingProviderId) return false;
        return userId == bookingProviderId;
      },
      "users:update": ({userId, userToEditId}) => {
        if (!userId || !userToEditId) return false;
        return userId == userToEditId;
      },
      "users:updatePassword": ({userId, userToEditId}) => {
        if (!userId || !userToEditId) return false;
        return userId === userToEditId;
      }
    }
  }
};

export default rules;