using System.Data.SqlClient;
using System.Linq;
using Common;

namespace Mzto.DAL
{
    public class MztoDac
    {
        private MztoContext _context;
        public MztoDac(string dbServerName, string dbName)
        {
            _context = new MztoContext(GetConnectionString(dbServerName, dbName));
        }
        public static bool TestConnection(string dbServerName, string dbName)
        {
            var isConnectionSuccess = false;
            using (var context = new MztoContext(GetConnectionString(dbServerName, dbName)))
            {
                try
                {
                    context.Database.Connection.Open();
                    isConnectionSuccess = true;
                }
                catch (SqlException) { }
            }
            return isConnectionSuccess;
        }
        public DomainDto[] GetDomains()
        {
            return _context.Domains
                .AsDtoWithDependencies(_context)
                .ToArray();
        }
        public PowerCenterDto[] GetPowerCenters()
        {
            var domainDb = _context.Domains
                .Single(domain => domain.Id == 1);
            return domainDb.PowerCenters
                .Select(pc => new PowerCenterDto
                {
                    Name = pc.Name
                })
                .ToArray();
        }
        private static string GetConnectionString(string dbServerName, string dbName)
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = dbServerName.Trim(),
                InitialCatalog = dbName.Trim(),
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            }
            .ToString();
        }
    }
}
