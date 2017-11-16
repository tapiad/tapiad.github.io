using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DMV_Application.Models
{
    public class DMVRequest
    {

        public int ID { get; set; }

        public DateTime DOB { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public string County { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: DOB = {DOB} Zip = {Zip} ID = {ID}";
        }

    }
}