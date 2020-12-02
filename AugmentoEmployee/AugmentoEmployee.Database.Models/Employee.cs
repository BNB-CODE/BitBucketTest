using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AugmentoEmployee.Database.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FacilityId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name Cannot Exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name Cannot Exceed 50 characters")]
        public string Location { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTimeOffset DOJ { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTimeOffset ModifiedDate { get; set; }

    }
}
