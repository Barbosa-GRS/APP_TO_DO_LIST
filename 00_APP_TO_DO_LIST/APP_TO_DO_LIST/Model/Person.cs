using APP_TO_DO_LIST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model;
[Table("person")]
public class Person : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("address")]
    public string Address { get; set; }
    [Column("age")]
    public int Age { get; set; }

}
