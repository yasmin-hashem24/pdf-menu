CREATE MIGRATION m15ldct57padk2xbuqnmscje6vo2vduegywttjgws5y77smqiof6ma
    ONTO m1ua5g4cgbxgjl7vpphwkoq7pvpz2ctcnvdoosk7mzv7bdi3nq6n7q
{
  ALTER TYPE default::restaurant {
      CREATE REQUIRED PROPERTY district: std::str {
          SET REQUIRED USING (<std::str>{});
      };
  };
  ALTER TYPE default::restaurant {
      DROP PROPERTY districts;
  };
  ALTER TYPE default::restaurant {
      CREATE REQUIRED PROPERTY phone_number: std::str {
          SET REQUIRED USING (<std::str>{});
      };
  };
  ALTER TYPE default::restaurant {
      DROP PROPERTY phone_numbers;
  };
  ALTER TYPE default::restaurant {
      CREATE PROPERTY rating: std::int16;
  };
  ALTER TYPE default::restaurant_filter {
      CREATE PROPERTY district: std::str;
  };
  ALTER TYPE default::restaurant_filter {
      DROP PROPERTY districts;
  };
  CREATE TYPE default::top_rated {
      CREATE PROPERTY name: std::str;
  };
  CREATE TYPE default::user {
      CREATE REQUIRED PROPERTY email: std::str;
      CREATE REQUIRED PROPERTY name: std::str;
      CREATE REQUIRED PROPERTY password: std::str;
      CREATE REQUIRED PROPERTY phone_number: std::str;
      CREATE REQUIRED PROPERTY resturant_name: std::str;
      CREATE REQUIRED PROPERTY role: std::str;
  };
};
