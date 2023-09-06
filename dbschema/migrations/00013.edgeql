CREATE MIGRATION m1onz5h4rxo3atjvsaa3ifz5h2sr3dm4jo44ixk7m5h5gt2c2khvkq
    ONTO m1uuwwm5g62pam6fzynnrc4yawqezgqymhbb34felfmnd6q7rmyh5a
{
  ALTER TYPE default::restaurant {
      DROP PROPERTY menu_upload_date;
      CREATE PROPERTY menu_upload_date: cal::local_date;
  };
};
