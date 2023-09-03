CREATE MIGRATION m1e63pryxitzmjmyqqwvloopsmq4co64gch7t2wqe4g2mkebszw7qa
    ONTO m1xtafssvtbt3s7ymbxrpnmktdpu674pawlejdygbycypk6vnpoatq
{
  ALTER TYPE default::restaurant {
      ALTER PROPERTY district {
          RESET OPTIONALITY;
      };
  };
  ALTER TYPE default::restaurant {
      ALTER PROPERTY facebook_link {
          RENAME TO city;
      };
  };
  ALTER TYPE default::restaurant {
      CREATE PROPERTY instagram: std::str;
  };
  ALTER TYPE default::restaurant {
      ALTER PROPERTY instagram_link {
          RENAME TO facebook;
      };
  };
  ALTER TYPE default::restaurant {
      ALTER PROPERTY name {
          RENAME TO country;
      };
  };
  ALTER TYPE default::restaurant {
      CREATE REQUIRED PROPERTY resturant: std::str {
          SET REQUIRED USING (<std::str>{});
      };
      CREATE PROPERTY twitter: std::str;
  };
};
