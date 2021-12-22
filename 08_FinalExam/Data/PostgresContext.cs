using System.Data;
using Npgsql;

namespace ProblemBasedCase.Data
{
    public class PostgresContext
    {
        private const string ConnectionString =
            "Server=209.126.96.59;User Id=u107417;Password=DVZ7USF8;Database=adv_prog;";
        private DataTable DataTable { get; } = new DataTable();
        public DataTable GetAllStores()
        {
            DataTable?.Clear();
            const string sql = "SELECT * FROM stores;";
            using var dataAdapter = new NpgsqlDataAdapter(sql, ConnectionString);
            dataAdapter.Fill(DataTable!);
            return DataTable;
        }
        
        public static void DeleteStore(long id)
        {
            const string sql = "DELETE FROM stores WHERE store_id = @ID";
            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            using var command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
        }

        public static void Insert(Store store)
        {
            const string sql =
                @"INSERT INTO stores (store_name, shirt_boxes, max_shirt_boxes, shoe_packs, max_shoe_packs, 
                                      suit_packs, max_suit_packs)
                  VALUES (@storeName, @shirtBoxes, @maxShirtBoxes, @shoePacks, @maxShoePacks, @suitPacks, 
                          @maxSuitPacks);";

            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            using var command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@storeName", store.StoreName);
            command.Parameters.AddWithValue("@shirtBoxes", store.ShirtBoxes);
            command.Parameters.AddWithValue("@maxShirtBoxes", store.MaxShirtBoxes);
            command.Parameters.AddWithValue("@shoePacks", store.ShoePacks);
            command.Parameters.AddWithValue("@maxShoePacks", store.MaxShoePacks);
            command.Parameters.AddWithValue("@suitPacks", store.SuitPacks);
            command.Parameters.AddWithValue("@maxSuitPacks", store.MaxSuitPacks);
            command.ExecuteNonQuery();
        }

        public static void Update(Store store)
        {
            const string sql = @"UPDATE stores
                        SET store_name = @storeName, 
	                        shirt_boxes = @shirtBoxes, 
	                        max_shirt_boxes = @maxShirtBoxes, 
	                        shoe_packs = @shoePacks, 
	                        max_shoe_packs = @maxShoePacks, 
	                        suit_packs = @suitPacks, 
	                        max_suit_packs = @maxSuitPacks
                        WHERE store_id = @storeId;";
            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            using var command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@storeName", store.StoreName);
            command.Parameters.AddWithValue("@shirtBoxes", store.ShirtBoxes);
            command.Parameters.AddWithValue("@maxShirtBoxes", store.MaxShirtBoxes);
            command.Parameters.AddWithValue("@shoePacks", store.ShoePacks);
            command.Parameters.AddWithValue("@maxShoePacks", store.MaxShoePacks);
            command.Parameters.AddWithValue("@suitPacks", store.SuitPacks);
            command.Parameters.AddWithValue("@maxSuitPacks", store.MaxSuitPacks);
            command.Parameters.AddWithValue("@storeId", store.StoreId);
            command.ExecuteNonQuery();
        }
    }
}