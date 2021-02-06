using System.Collections.Generic;
using System.Data;

namespace ProblemBasedCase6.Data
{
    public static class CountryMapper
    {
        public static IEnumerable<CountryModel> Map(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                yield return null;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                yield return new CountryModel
                {
                    Id = row["id"].ToString(),
                    Value = row["value"].ToString(),
                };
            }
        }
    }
}