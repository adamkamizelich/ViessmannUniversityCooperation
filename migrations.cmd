SET AssemblyName=UniversityIot.UsersDataAccess
SET StartUpDirectory=UniversityIot.UsersDataAccess\bin\Debug
SET ConnectionString=Server=tcp:universityiotdb.database.windows.net,1433;Initial Catalog=udb_UsersDataAccess;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;MultipleActiveResultSets=True
SET ConnectionStringProvider=System.Data.SqlClient
SET ConfigFilePath=%CD%\UniversityIot.UsersDataAccess\app.config
SET MigrateExe=packages\EntityFramework.6.1.3\tools\migrate.exe

%MigrateExe% %AssemblyName%.dll /startUpDirectory:%StartUpDirectory% /startUpConfigurationFile:"%ConfigFilePath%" /connectionProviderName:"%ConnectionStringProvider%" /connectionString:"%ConnectionString%" /verbose