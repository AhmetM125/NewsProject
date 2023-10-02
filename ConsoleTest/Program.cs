using ConsoleTest.GetCustomTableName;
using EntityLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

class HelloWorld
{
    static void Main()
    {

        var entityType = typeof(Admin);
        var primaryKeyProperty = entityType.GetProperties()
                                          .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));



        TableNameCustom tableName  = new TableNameCustom();
        Console.Write(primaryKeyProperty.Name);
        var T = tableName.GetTableName(typeof(Admin));
        Console.WriteLine($"Table name for Admin class: {T}");

    }
    
}