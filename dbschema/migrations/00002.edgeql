CREATE MIGRATION m1bn2wg5jua2ge6qthc7n2ka4l3bzalsnytbd4yvijvdnjigoahb3q
    ONTO m1snhkkc7cxfxhxvjrlrly52awandr7aymhhmrpgduh6proqipnwma
{
  DROP TYPE default::Restaurant;
  ALTER TYPE default::RestaurantFilter RENAME TO default::restaurant_filter;
  CREATE TYPE default::restaurant {
      CREATE PROPERTY cover_photo: std::str;
      CREATE REQUIRED PROPERTY districts: array<std::str>;
      CREATE REQUIRED PROPERTY email: std::str;
      CREATE PROPERTY facebook_link: std::str;
      CREATE PROPERTY instagram_link: std::str;
      CREATE PROPERTY menu_pdf: std::str;
      CREATE REQUIRED PROPERTY name: std::str;
      CREATE PROPERTY opening_hours: std::str;
      CREATE REQUIRED PROPERTY password: std::str;
      CREATE REQUIRED PROPERTY phone_numbers: array<std::str>;
      CREATE PROPERTY tags: array<std::str>;
  };
  ALTER TYPE default::restaurant_filter {
      ALTER PROPERTY Districts {
          RENAME TO districts;
      };
  };
  ALTER TYPE default::restaurant_filter {
      ALTER PROPERTY Location {
          RENAME TO location;
      };
  };
  ALTER TYPE default::restaurant_filter {
      ALTER PROPERTY Name {
          RENAME TO name;
      };
  };
  ALTER TYPE default::restaurant_filter {
      ALTER PROPERTY Tags {
          RENAME TO tags;
      };
  };
};
