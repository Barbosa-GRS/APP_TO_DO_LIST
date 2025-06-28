using APP_TO_DO_LIST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model;

[Table("country")]
public class Country : BaseEntity
{
    [Column("acronym")]
    public string? Acronym { get; set; }

    [Column("countryName")]
    public string? CountryName { get; set; }

    public virtual List <Region> Regions { get; set; }
}
