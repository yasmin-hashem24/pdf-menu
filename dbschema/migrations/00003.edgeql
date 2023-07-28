CREATE MIGRATION m1ua5g4cgbxgjl7vpphwkoq7pvpz2ctcnvdoosk7mzv7bdi3nq6n7q
    ONTO m1bn2wg5jua2ge6qthc7n2ka4l3bzalsnytbd4yvijvdnjigoahb3q
{
  ALTER TYPE default::restaurant {
      CREATE PROPERTY menu_upload_date: std::datetime;
  };
};
