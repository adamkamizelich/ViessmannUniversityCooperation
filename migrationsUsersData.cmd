SET AssemblyName=UniversityIot.UsersDataAccess
SET StartUpDirectory=Source\UniversityIot.UsersDataAccess\bin\Debug
SET ConnectionString=Server=tcp:universityiotdb.database.windows.net,1433;Initial Catalog=udb_UsersDataAccess;Persist Security Info=False;User ID=u_admin;Password=Adm12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
SET ConnectionStringProvider=System.Data.SqlClient
SET ConfigFilePath=%CD%\UniversityIot.UsersDataAccess\app.config
SET MigrateExe=packages\EntityFramework.6.1.3\tools\migrate.exe

%MigrateExe% %AssemblyName%.dll /startUpDirectory:%StartUpDirectory% /startUpConfigurationFile:"%ConfigFilePath%" /connectionProviderName:"%ConnectionStringProvider%" /connectionString:"%ConnectionString%" /verbose