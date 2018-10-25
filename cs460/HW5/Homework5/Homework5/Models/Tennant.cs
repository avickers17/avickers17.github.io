using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework5.Models
{
    public class Tennant
    {
        [Key]
        public int ID { get; set; }

        [Display(Name= "First Name:"), Required(ErrorMessage = "Name must be at least 3 characters long")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:"), Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters long")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number:"), Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$", ErrorMessage = "Enter Phone Number like 999-999-9999")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Apartment Name:"), Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters long")]
        public string ApartmentName {get; set; }

        [Display(Name = "Unit Number:"), Required]
        public int UnitNumber { get; set; }

        [Required]
        public string TextBox { get; set; }

        [Required]
        public bool CheckBox { get; set; }

        private DateTime date = DateTime.Now;

        public DateTime VerifiedDate
        {
            get { return date; }
            set { date = value; }
        }

    }

}