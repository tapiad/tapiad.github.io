using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DMV_Application.Models
{
    /// <summary>
    /// The Model of a DMV Request
    /// </summary>
    public class DMVRequest
    {
        [Required(ErrorMessage = "Your Id number please (3-digits)")]
        [MinLength(3)]
        [Display(Name = "Customer ID")]
        public int ID { get; set; }

        [StringLength(64)]
        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }

        [Required(ErrorMessage ="Please Enter Your Name Full Legal Name")]
        [Display(Name = "Full Legal Name")]
        [StringLength(128)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter New Address")]
        [Display(Name = "New Address")]
        [StringLength(128)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter City")]
        [StringLength(64)]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter City")]
        [StringLength(64)]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter Zip Code")]
        [Display(Name = "Zip Code")]
        [MinLength(5)]
        public int Zip { get; set; }

        [StringLength(64)]
        public string County { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: Zip = {Zip} ID = {ID}";
        }

    }
}