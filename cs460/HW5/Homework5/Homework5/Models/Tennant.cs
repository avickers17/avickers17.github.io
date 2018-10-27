using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework5.Models
{
    public class Tennant
    {
        //tennant class to be used within the db and for get/post requests
        [Key]
        public int ID { get; set; }

        [Display(Name= "First Name:"), Required(ErrorMessage = "Name must be at least 3 characters long")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:"), Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters long")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number:"), Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$", ErrorMessage = "Enter Phone Number in the format of: 999-999-9999")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Apartment Name:"), Required]
        [StringLength(30, ErrorMessage = "Name must be at least 3 characters long")]
        public string ApartmentName {get; set; }

        [Display(Name = "Unit Number:"), Required]
        [RegularExpression("^[0-9]{2}$", ErrorMessage = "Enter A One-Two Digit Number")]
        public int UnitNumber { get; set; }

        [Display(Name = "Request Details:"), Required]
        public string TextBox { get; set; }

        [Display(Name = "Entry Permission:")]
        public bool CheckBox { get; set; }

        private DateTime Date = DateTime.Now;

        //VerifiedDate set by date class to set when the tennant class has been created
        [Display(Name = "Submission Date:")]
        public DateTime VerifiedDate
        {
            get { return Date; }
            set { Date = value; }
        }

    }

}