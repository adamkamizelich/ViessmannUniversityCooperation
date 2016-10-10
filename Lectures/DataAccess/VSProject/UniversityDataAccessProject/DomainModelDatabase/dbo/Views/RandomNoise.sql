CREATE VIEW dbo.RandomNoise
AS
-- helper view for accessing CRYPT_GEN_RANDOM from UDF
-- see dbo.GeneratePassword for details about 2048 value
SELECT CRYPT_GEN_RANDOM(2048) Bytes
