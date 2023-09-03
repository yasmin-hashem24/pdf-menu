CREATE MIGRATION m1kgctbgw7ccr4sfsely6stga36dvhcyo3xkci7zjabezc6gletwxq
    ONTO m1w32n743gpipghudqa5livimumjjyvtcszylblbjc45dfhzi7msla
{
  ALTER TYPE default::restaurant {
      ALTER PROPERTY resturant {
          RENAME TO restaurant;
      };
  };
};
