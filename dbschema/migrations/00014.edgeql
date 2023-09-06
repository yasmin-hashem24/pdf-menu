CREATE MIGRATION m1nscwivf5va5jykl7fxvl4zf4bpu3rjoiubuablggd3wlchmpsbpa
    ONTO m1onz5h4rxo3atjvsaa3ifz5h2sr3dm4jo44ixk7m5h5gt2c2khvkq
{
  ALTER TYPE default::restaurant {
      DROP PROPERTY menu_upload_date;
      CREATE PROPERTY menu_upload_date: std::datetime;
  };
  DROP TYPE default::restaurant_filter;
};
