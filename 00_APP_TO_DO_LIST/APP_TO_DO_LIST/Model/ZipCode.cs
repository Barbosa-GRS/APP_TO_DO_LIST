using System.ComponentModel.DataAnnotations.Schema;

namespace APP_TO_DO_LIST.Model;
[Table("zip_code")]
public class ZipCode
{
    [Column("zip_code")]
    public string ZipCodeNumber { get; set; }

    [Column("street")]
    public string Street { get; set; }

    [Column("neighborhood")]
    public string Neighborhood { get; set; }

    [Column("city")]
    public string City { get; set; }

    public virtual Adress Adress { get; set; } // relação 1:1


}
