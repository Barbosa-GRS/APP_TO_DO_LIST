using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model
{
    [Table("todolist")]
    public class ToDoList
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Status")]
        public string Status { get; set; }


    }
}
