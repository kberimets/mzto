namespace Mzto.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OikCategory")]
    internal partial class OikCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OikCategory()
        {
            Parameters = new HashSet<Parameter>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(1)]
        public string OikLetter { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parameter> Parameters { get; set; }
    }
}
