using System;
using Microsoft.Extensions.Options;
//using ServiceStack.OrmLite;

namespace FluencyMath.Repositories
{
    public class RepositoryBase
    {
        //public static OrmLiteConnectionFactory RecruitingDataFactory;

        //public RepositoryBase(IOptions<AppSettings> _appSettings)
        //{
        //    var appSettings = _appSettings.Value;
        //    var dialectProvider = appSettings.DatabaseType switch
        //    {
        //        "MSSQLLocalDB" => SqlServerDialect.Provider,
        //        "SQLite3" => SqliteDialect.Provider,
        //        _ => throw new Exception($"Unrecognized database type '{appSettings.DatabaseType}'")
        //    };
            
        //    RecruitingDataFactory = new OrmLiteConnectionFactory(appSettings.ConnectionString, dialectProvider);
        //    RecruitingDataFactory.DialectProvider.NamingStrategy = new OrmLiteNamingStrategyBase();
        //}
    }
}
