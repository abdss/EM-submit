using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace DeliveryService.DAL
{
    public class AzureSqlEntityFrameworkConfiguration : DbConfiguration
    {
        public AzureSqlEntityFrameworkConfiguration()
        {
            this.SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}