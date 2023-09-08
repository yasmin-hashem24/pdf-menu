CREATE MIGRATION m1mzcuctdtbp2wv7wqua6l7niw7k5mcamomksbbyydcx6v2qujwauq
    ONTO m1nscwivf5va5jykl7fxvl4zf4bpu3rjoiubuablggd3wlchmpsbpa
{
  CREATE TYPE default::history {
      CREATE PROPERTY menu_pdf: std::str;
      CREATE PROPERTY menu_upload_date: std::datetime;
  };
};
