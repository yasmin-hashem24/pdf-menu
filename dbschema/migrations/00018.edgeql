CREATE MIGRATION m13bfuh2nhooj6qodc55x4qcvuwozeyh7tadvznq33bpo7stozwq4a
    ONTO m1sl2azetlmuc3z2kcx62pvncifhpetyuilfyuqijemxv4wrynp5ca
{
  ALTER TYPE default::restaurant {
      CREATE MULTI LINK users: default::user;
  };
  ALTER TYPE default::user {
      DROP LINK resturant_name;
      DROP PROPERTY password;
      DROP PROPERTY role;
  };
};
