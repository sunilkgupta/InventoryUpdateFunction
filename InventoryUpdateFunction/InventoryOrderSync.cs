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
    /// <summary>
    /// Function gets fire immediate whenever there is change/add in Order tbl.
    /// </summary>
    public static class InventoryOrderSync
    {
        [FunctionName(Constants.Function_Name)]
        public static void Run([SqlTrigger(Constants.Tbl_Name, Constants.ConnString_Config)]
            IReadOnlyList<SqlChange<Order>> changes, ILogger log)
        {
            log.LogInformation("SQL Changes: " + JsonConvert.SerializeObject(changes));

            var str = Environment.GetEnvironmentVariable("DbConnection");
            using var conn = new SqlConnection(str);
            conn.Open();
            try
            {
                var sp_Name = Constants.SP_Name;

                using (var cmd = new SqlCommand(sp_Name, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(Constants.Input_id, changes[0].Item.ItemId));
                    cmd.Parameters.Add(new SqlParameter(Constants.Input_Quantity, changes[0].Item.Quantity));
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

    /// <summary>
    /// Object as Order class model
    /// </summary>
    public class Order
    {
        public Guid OrderId { get; set; }
        public string? CustomerName { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
