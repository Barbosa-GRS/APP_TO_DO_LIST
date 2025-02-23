using APP_TO_DO_LIST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model;
[Table("person")]
public class Person : BaseEntity
{
    
    [Column("name")]
    public string Name { get; set; }

    [Column("street")]
    public string Street { get; set; }

    [Column("number")]
    public string Number { get; set; }

    [Column("zip_code")]
    public string ZipCode { get; set; }

    [Column("city")]
    public string City { get; set; }

    [Column("state")]
    public string State { get; set; }

    [Column("age")]
    public int Age { get; set; }

    
    public List<ToDoList>  ToDoLists { get; set; } 

}
