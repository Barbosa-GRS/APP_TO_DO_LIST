using APP_TO_DO_LIST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model;
[Table("region")]

public class Region : BaseEntity
{
    [Column("acronym")]
    public string Acronym { get; set; }

    [Column("regionName")]
    public string RegionName { get; set; }

    [Column("countryId")]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }

    public virtual Adress Adress { get; set; }
}
