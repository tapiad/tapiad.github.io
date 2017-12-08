namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cast
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Cast()
        //{
          //  Movies = new HashSet<Movie>();
        //}


        //[Key]
        //public int ID { get; set; }

        [Key]
        [StringLength(50)]
        public string Actor { get; set; }

        
        //public virtual Actor Actor1 { get; set; }

        
        [StringLength(50)]
        public string Movie { get; set; }

        
        //public virtual Movie Movie1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Movie> Movies { get; set; }
    }
}