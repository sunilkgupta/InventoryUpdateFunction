using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InventoryUpdateFunction
{
    public static class InventoryOrderSync
    {
        [FunctionName("DbSyncTrigger")]
        public static void Run([SqlTrigger("[dbo].[Order]", "DbConnection")]
            IReadOnlyList<SqlChange<Order>> changes,
            ILogger log)
        {
            log.LogInformation("SQL Changes: " + JsonConvert.SerializeObject(changes));

            var str = Environment.GetEnvironmentVariable("DbConnection");
            using (var conn = new SqlConnection(str))
            {
                conn.Open();
                try
                {
                    var sp_Name = "UpdateInventoryUponNewOrder";

                    using (var cmd = new SqlCommand(sp_Name, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", changes[0].Item.ItemId));
                        cmd.Parameters.Add(new SqlParameter("@Quantity", changes[0].Item.Quantity));
                        cmd.ExecuteNonQuery();
                        log.LogInformation($"Inventory updated successfully");
                    }
                }
                catch (Exception ex)
                {
                    log.LogError(ex.Message, ex);
                    throw;
                }
                finally
                {
                    conn.Close();
                    log.LogInformation("SQL Cconnection closed!");
                    log.LogInformation("SQL Changes completed!");

                }
            }
        }
    }

    public class Order
    {
        public Guid OrderId { get; set; }

        public string? CustomerName { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
