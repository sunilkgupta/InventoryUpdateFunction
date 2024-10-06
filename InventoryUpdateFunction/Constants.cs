
namespace InventoryUpdateFunction
{
    /// <summary>
    /// Constants 
    /// </summary>
    public static class Constants
    {
        #region Important constants
        public const string SP_Name = "UpdateInventoryUponNewOrder";
        public const string Tbl_Name = "[dbo].[Order]";
        public const string ConnString_Config = "DbConnection";
        public const string Function_Name = "DbSyncTrigger";
        public const string Input_id = "@Id";
        public const string Input_Quantity = "@Quantity";
        #endregion

        #region log messages constants

        #endregion
    }
}
