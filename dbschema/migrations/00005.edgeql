CREATE MIGRATION m1clwtbfbqvasrtwczist2qoollhl7kyt3ney3qx6omjep7mshuvza
    ONTO m15ldct57padk2xbuqnmscje6vo2vduegywttjgws5y77smqiof6ma
{
  ALTER TYPE default::restaurant_filter {
      DROP PROPERTY name;
  };
  ALTER TYPE default::restaurant_filter {
      CREATE LINK name: default::restaurant;
  };
  ALTER TYPE default::top_rated {
      DROP PROPERTY name;
  };
  ALTER TYPE default::top_rated {
      CREATE LINK name: default::restaurant;
  };
  ALTER TYPE default::user {
      DROP PROPERTY resturant_name;
  };
  ALTER TYPE default::user {
      CREATE REQUIRED LINK resturant_name: default::restaurant {
          SET REQUIRED USING (<default::restaurant>{});
      };
  };
};
