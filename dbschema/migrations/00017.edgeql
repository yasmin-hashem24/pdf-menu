CREATE MIGRATION m1sl2azetlmuc3z2kcx62pvncifhpetyuilfyuqijemxv4wrynp5ca
    ONTO m1iewf7msfepn2c3pjnpg5s7vpri6on7g44p3ddrw6ywvcydv4ahsa
{
  ALTER TYPE default::restaurant {
      ALTER LINK uploads {
          RENAME TO menu_uploads;
      };
  };
};
