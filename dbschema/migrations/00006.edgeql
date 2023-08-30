CREATE MIGRATION m1xtafssvtbt3s7ymbxrpnmktdpu674pawlejdygbycypk6vnpoatq
    ONTO m1clwtbfbqvasrtwczist2qoollhl7kyt3ney3qx6omjep7mshuvza
{
  ALTER TYPE default::top_rated {
      DROP LINK name;
  };
  ALTER TYPE default::top_rated {
      CREATE PROPERTY name: std::str;
  };
};
