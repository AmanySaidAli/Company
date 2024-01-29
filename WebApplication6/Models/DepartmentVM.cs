using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter Department Name")]
        [MinLength(3,ErrorMessage = "min length 3")]
        [MaxLength(10,ErrorMessage = "Enter length")]

        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Enter Department Code")]

        public string DepartmentCode { get; set; }
    }
}
