CREATE MIGRATION m1quwvfhc4nhoe577jezgs4ztxehiiwzcmdlhezp3zxglqgihkqrrq
    ONTO m1srlg6atawpk5shvgpsjcnzzlrqcqhdhpw4gabdo3o5ljwiwmyusq
{
  ALTER TYPE default::restaurant {
      CREATE PROPERTY photo: std::str;
  };
};
