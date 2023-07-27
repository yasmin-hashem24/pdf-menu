CREATE MIGRATION m1snhkkc7cxfxhxvjrlrly52awandr7aymhhmrpgduh6proqipnwma
    ONTO initial
{
  CREATE TYPE default::Restaurant {
      CREATE REQUIRED PROPERTY Districts: array<std::str>;
      CREATE REQUIRED PROPERTY Email: std::str;
      CREATE PROPERTY FacebookLink: std::str;
      CREATE PROPERTY InstagramLink: std::str;
      CREATE PROPERTY MenuPDF: std::str;
      CREATE REQUIRED PROPERTY Name: std::str;
      CREATE PROPERTY OpeningHours: std::str;
      CREATE REQUIRED PROPERTY Password: std::str;
      CREATE REQUIRED PROPERTY PhoneNumbers: array<std::str>;
      CREATE PROPERTY Tags: array<std::str>;
  };
  CREATE TYPE default::RestaurantFilter {
      CREATE PROPERTY Districts: array<std::str>;
      CREATE PROPERTY Location: std::str;
      CREATE PROPERTY Name: std::str;
      CREATE PROPERTY Tags: array<std::str>;
  };
};
