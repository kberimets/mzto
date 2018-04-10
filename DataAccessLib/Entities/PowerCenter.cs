namespace Mzto.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PowerCenter")]
    internal partial class PowerCenter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PowerCenter()
        {
            Parameters = new HashSet<Parameter>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public bool IsObservable { get; set; }

        public int DomainId { get; set; }

        public virtual Domain Domain { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parameter> Parameters { get; set; }
    }
}
