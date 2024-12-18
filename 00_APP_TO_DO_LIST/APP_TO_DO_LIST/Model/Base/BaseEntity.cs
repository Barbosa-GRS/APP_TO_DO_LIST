using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model.Base
{
    public class BaseEntity
    {
        // for generic repository to use id 
        [Column("id")]
        public long Id { get; set; }
    }
}
