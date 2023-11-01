using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public Employee() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [StringLength(10)]
        public string Mobile { get; set; }

        [DateOfBirthValidation]
        public DateTime DOB { get; set; }
        public string DOBDateOnly { get; set; }
    }

    public class DateOfBirthValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateOfBirth = (DateTime)value;

            if(dateOfBirth > DateTime.Now.AddYears(-18))
            {
                return new ValidationResult("Date Of Birth at least 18 years ago");
            }
            return  ValidationResult.Success;
        }
    }
}