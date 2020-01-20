namespace WebBlog.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class blg_Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string Introduce { get; set; }

        public int? ParentId { get; set; }

        public int? OrderyId { get; set; }

        public DateTime CreateTime { get; set; }

        public int? IsDel { get; set; }
    }
}
