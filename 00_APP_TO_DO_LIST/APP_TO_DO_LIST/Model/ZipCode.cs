using APP_TO_DO_LIST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APP_TO_DO_LIST.Model;
[Table("zip_code")]
public class ZipCode : BaseEntity
{
    [Column("zip_code")]
    public string? ZipCodeNumber { get; set; }

    [Column("street")]
    public string? Street { get; set; }

    [Column("neighborhood")]
    public string? Neighborhood { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [JsonIgnore]
    public virtual List<Adress>? Adresses { get; set; } 


}
