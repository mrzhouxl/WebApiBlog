namespace WebBlog.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class blg_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public blg_user()
        {
            blg_article = new HashSet<blg_article>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int? password { get; set; }

        [StringLength(200)]
        public string pictureImg { get; set; }

        [StringLength(2000)]
        public string introduce { get; set; }

        public int? sex { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public DateTime CreateTime { get; set; }

        public int? IsDel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<blg_article> blg_article { get; set; }
    }
}
