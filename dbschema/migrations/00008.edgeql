CREATE MIGRATION m1w32n743gpipghudqa5livimumjjyvtcszylblbjc45dfhzi7msla
    ONTO m1e63pryxitzmjmyqqwvloopsmq4co64gch7t2wqe4g2mkebszw7qa
{
  ALTER TYPE default::restaurant {
      CREATE REQUIRED PROPERTY address: std::str {
          SET REQUIRED USING (<std::str>{});
      };
  };
};
