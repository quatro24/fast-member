using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class SqlBulkCopyExtensions
    {
        public static void AddMappings<TEntity>(this SqlBulkCopy sqlBulkCopy, IEnumerable<TEntity> data)
        {
            var properties = (typeof(TEntity)).GetProperties()
                                      .Where(x => x.GetCustomAttributes(typeof(DataColumnAttribute), true).Any())
                                      .ToList();

            foreach (var property in properties)
                sqlBulkCopy.ColumnMappings.Add(property.Name,
                    (property.GetCustomAttributes(typeof(DataColumnAttribute), true).FirstOrDefault() as DataColumnAttribute).Name);
        }
    }
}
