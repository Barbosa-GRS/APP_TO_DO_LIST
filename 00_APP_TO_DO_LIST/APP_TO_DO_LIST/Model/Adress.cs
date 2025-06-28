using APP_TO_DO_LIST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APP_TO_DO_LIST.Model;

[Table("adress")]
public class Adress : BaseEntity
{
    [Column("number")]
    public string Number { get; set; }

    [Column("zipCodeId")]
    public int ZipCodeId { get; set; }

    public virtual ZipCode? ZipCode { get; set; }

    [Column("regionId")]
    public int RegionId { get; set; }
    [JsonIgnore]
    public virtual Region? Region { get; set; }

    [JsonIgnore]
    public virtual Person? Person { get; set; }
}
