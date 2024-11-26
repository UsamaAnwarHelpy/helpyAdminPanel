using System.Data.Common;

namespace HelpyAdmin.Controllers.Helper
{
    public static class DataReaderMapper
    {
        public static T MapTo<T>(this DbDataReader reader) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                try
                {
                    if (!reader.HasColumn(property.Name) || reader[property.Name] == DBNull.Value)
                        continue;

                    var value = reader[property.Name];
                    if (value != null && property.CanWrite)
                    {
                        property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                    }
                }
                catch (Exception ex)
                {
                    // Handle mapping errors (optional)
                    Console.WriteLine($"Error mapping property {property.Name}: {ex.Message}");
                }
            }

            return obj;
        }

        public static bool HasColumn(this DbDataReader reader, string columnName)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }


}
