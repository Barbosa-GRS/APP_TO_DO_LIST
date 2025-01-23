using APP_TO_DO_LIST.Enums;
using APP_TO_DO_LIST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model;



[Table("to_do_list")]
public class ToDoList : BaseEntity
{
    
    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("status")]
    public ToDoListStatus Status { get; set; }

    [Column("person_id")]
    public long Person_id { get; set; } 

    [Column("person")]
    public Person ? Person { get; set; }
}
