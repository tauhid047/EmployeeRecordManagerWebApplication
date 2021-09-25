using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordManagerWebApplication.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters allowed")]
        public string FirstName { get; set; }

        [MaxLength(10, ErrorMessage = "Maximum 10 characters allowed")]
        public string MiddleName { get; set; }
        
        [Required]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters allowed")]
        public string LastName { get; set; }
    }
}
