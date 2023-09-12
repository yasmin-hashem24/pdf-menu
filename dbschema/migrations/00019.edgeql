CREATE MIGRATION m1b5fjsc6ydxtptdyrmoeckdacvd7strmcfsicgadnmal2vo4idzeq
    ONTO m13bfuh2nhooj6qodc55x4qcvuwozeyh7tadvznq33bpo7stozwq4a
{
  ALTER TYPE default::restaurant {
      ALTER LINK users {
          ON TARGET DELETE ALLOW;
      };
  };
};
