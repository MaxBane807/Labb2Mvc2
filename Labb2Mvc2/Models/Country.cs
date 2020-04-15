using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Mvc2.Models
{
    [Table("country")]
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        [Key]
        [Column("country_id")]
        public short CountryId { get; set; }
        [Required]
        [Column("country")]
        [StringLength(50)]
        public string Country1 { get; set; }
        [Column("last_update", TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<City> City { get; set; }
    }
}
