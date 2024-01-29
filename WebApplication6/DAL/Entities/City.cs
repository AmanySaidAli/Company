using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication6.DAL.Entities
{

    [Table("City")]

    public class City
    {

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public virtual ICollection<District> District { get; set; }

    }
}
