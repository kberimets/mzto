namespace Mzto.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parameter")]
    internal partial class Parameter
    {
        public int Id { get; set; }

        public int OikCategoryId { get; set; }

        public int OikId { get; set; }

        public int TypeId { get; set; }

        public int PowerCenterId { get; set; }

        public virtual OikCategory OikCategory { get; set; }

        public virtual PowerCenter PowerCenter { get; set; }

        public virtual ParameterType ParameterType { get; set; }
    }
}
