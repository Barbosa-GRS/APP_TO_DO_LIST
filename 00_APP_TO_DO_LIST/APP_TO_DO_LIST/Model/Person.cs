using APP_TO_DO_LIST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APP_TO_DO_LIST.Model;

[Table("person")]
public class Person : BaseEntity
{
    
    [Column("name")]
    public string Name { get; set; }

    [Column("age")]
    public int Age { get; set; }

    [Column("adressId")]
    public int AdressId { get; set; }

    [JsonIgnore]
    public virtual Adress Adress { get; set; }

    public List<ToDoList>  ToDoLists { get; set; }

  

}
