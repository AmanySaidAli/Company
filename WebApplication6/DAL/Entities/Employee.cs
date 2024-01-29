using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.DAL.Entities
{
    [Table("Employee")]

    public class Employee
    {


        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public float Salary { get; set; }
        public string Address { get; set; }

        public bool IsActive { get; set; }

        public DateTime HirData { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        public string Notes { get; set; }


        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}
