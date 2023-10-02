using Dapper.Contrib.Extensions;

namespace ConsoleTest.GetCustomTableName
{
    public class TableNameCustom
    {
        public string GetTableName(Type entityType)
        {
            var tableAttribute = (TableAttribute)Attribute.GetCustomAttribute(entityType, typeof(TableAttribute));
            if (tableAttribute != null)
            {
                
                return tableAttribute.Name;
            }
            else
            {
                // Default table name logic if the TableAttribute is not specified
                // For example, you could return entityType.Name;
                return entityType.Name;
            }
        }
    }
}
