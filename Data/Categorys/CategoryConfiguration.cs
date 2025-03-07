
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Categorys
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Category");
            this.HasKey(a => a.Name);
        }
    }
}



