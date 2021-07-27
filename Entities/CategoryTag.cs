using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class CategoryTag : BaseEntity
    {
        public int CategoryID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }

        public int? TagID { get; set; }

        [ForeignKey(nameof(TagID))]
        public Tag Tag { get; set; }

        //Should Think
        //Category Tag with itself
        /// <summary>
        /// ارتباط جدول با خودش برای ایجاد ارتباط پدر فرزندی
        /// </summary>
        public int? ParentID { get; set; }

        [ForeignKey(nameof(ParentID))]
        public CategoryTag Parent { get; set; }

        public ICollection<CategoryTag> Childen { get; set; }


    }
    public class CategoryTagConfiguration : IEntityTypeConfiguration<CategoryTag>
    {
        public void Configure(EntityTypeBuilder<CategoryTag> builder)
        {
            builder.HasOne(p => p.Category).WithMany(c => c.CategoryTags).HasForeignKey(p => p.CategoryID);
            builder.HasOne(p => p.Tag).WithMany(c => c.CategoryTags).HasForeignKey(p => p.TagID);
        }
    }
}
