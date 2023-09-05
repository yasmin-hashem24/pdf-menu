CREATE MIGRATION m1uuwwm5g62pam6fzynnrc4yawqezgqymhbb34felfmnd6q7rmyh5a
    ONTO m1quwvfhc4nhoe577jezgs4ztxehiiwzcmdlhezp3zxglqgihkqrrq
{
  ALTER TYPE default::restaurant {
      ALTER PROPERTY photo {
          RENAME TO main_photo;
      };
  };
};
