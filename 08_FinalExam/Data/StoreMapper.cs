using System.Collections.Generic;
using System.Data;

namespace ProblemBasedCase.Data
{
    public static class StoreMapper
    {
        public static IEnumerable<Store> Map(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                yield return null;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                yield return new Store
                {
                    StoreId = long.Parse(row["store_id"].ToString()!),
                    StoreName = row["store_name"].ToString(),
                    ShirtBoxes = int.Parse(row["shirt_boxes"].ToString()!),
                    MaxShirtBoxes = int.Parse(row["max_shirt_boxes"].ToString()!),
                    ShoePacks = int.Parse(row["shoe_packs"].ToString()!),
                    MaxShoePacks = int.Parse(row["max_shoe_packs"].ToString()!),
                    SuitPacks = int.Parse(row["suit_packs"].ToString()!),
                    MaxSuitPacks = int.Parse(row["max_suit_packs"].ToString()!),
                };
            }
        }
    }
}