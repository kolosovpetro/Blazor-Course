using System;
using System.Collections.Generic;
using System.Data;

namespace ProblemBasedCase6.Data
{
    public static class LanguageMapper
    {
        public static IEnumerable<LanguageModel> Map(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                yield return null;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                var parsed = Enum
                    .TryParse<LanguageEnum>(row["language_enum"].ToString(), out var val);
                
                yield return new LanguageModel
                {
                    LanguageId = int.Parse(row["language_id"].ToString()!),
                    LanguageName = row["language_name"].ToString(),
                    EnumValue = parsed ? val : LanguageEnum.CSharp
                };
            }
        }
    }
}