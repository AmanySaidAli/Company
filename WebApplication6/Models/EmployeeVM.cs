using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApplication6.Models
{
    public class EmployeeVM
    {

        [Required]  
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter Name ")]
        [MinLength(3, ErrorMessage = "min length 3")]
        [MaxLength(10, ErrorMessage = "Enter length")]

         public string Name { get; set; }

        [Required(ErrorMessage = "Enter Salary ")]
        [Range( 3000 , 10000 ,ErrorMessage = "Enter Salary from 3000 to 10000 ")]

        public float Salary { get; set; }

        [Required(ErrorMessage = "Enter Address ")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter Like 12-StreetName-CityName-Country ")]

        public string Address { get; set; }
        public bool IsActive { get; set; }

        public DateTime HirData { get; set; }
        public string Email { get; set; }

        public string Notes { get; set; }


        public string DepartmentId { get; set; }
        public string DistrictId { get; set; }


    }
}
