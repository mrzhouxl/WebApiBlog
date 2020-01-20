namespace WebBlog.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class blg_article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public blg_article()
        {
            blg_article_tag = new HashSet<blg_article_tag>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Type { get; set; }

        [StringLength(50)]
        public string Img { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public int? Status { get; set; }

        public int? CanTop { get; set; }

        public int? CanComment { get; set; }

        public int? ViewCount { get; set; }

        public int? GoodNum { get; set; }

        public int? UserId { get; set; }

        public DateTime CreateTime { get; set; }

        public int? IsDel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<blg_article_tag> blg_article_tag { get; set; }

        public virtual blg_user blg_user { get; set; }
    }
}
