namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class Movie
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Movie()
       // {
           // Casts = new HashSet<Cast>();
        //}
           
        
        [Key]
        [StringLength(50)]
        public string Title { get; set; }

        public int Year { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

        public virtual Director Director1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Cast> Casts { get; set; }
    }
}