using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication6.DAL.Entities
{

    [Table("District")]

    public class District
    {

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string DistrictName { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }


    }
}
