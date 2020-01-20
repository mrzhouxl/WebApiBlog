namespace WebBlog.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class blg_article_tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? artucleId { get; set; }

        public int? tagId { get; set; }

        public DateTime CreateTime { get; set; }

        public int? IsDel { get; set; }

        public virtual blg_article blg_article { get; set; }

        public virtual blg_tag blg_tag { get; set; }
    }
}
