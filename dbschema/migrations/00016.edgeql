CREATE MIGRATION m1iewf7msfepn2c3pjnpg5s7vpri6on7g44p3ddrw6ywvcydv4ahsa
    ONTO m1mzcuctdtbp2wv7wqua6l7niw7k5mcamomksbbyydcx6v2qujwauq
{
  ALTER TYPE default::restaurant {
      CREATE MULTI LINK uploads: default::history;
  };
};
