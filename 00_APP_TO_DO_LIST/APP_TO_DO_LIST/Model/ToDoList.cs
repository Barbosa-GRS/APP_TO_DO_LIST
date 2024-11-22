using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model
{
    [Table ("to_do_list")]
    public class ToDoList
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("status")]
        public string Status { get; set; }


    }
}
