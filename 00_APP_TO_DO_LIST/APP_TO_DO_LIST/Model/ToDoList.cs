using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model
{
    public enum ToDoListStatus
    {
        Pending = 1,
        InProcess = 2,
        Completed = 3,
    }

    [Table("to_do_list")]
    public class ToDoList
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("status")]
        public ToDoListStatus Status { get; set; }
    }
}
