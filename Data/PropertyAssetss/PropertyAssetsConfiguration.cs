
using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.PropertyAssetss
{
        public class PropertyAssetsConfiguration : EntityTypeConfiguration<PropertyAssets>
        {
            public PropertyAssetsConfiguration()
            {
                ToTable("PropertyAssets");
                this.HasKey(a => a.Id);
            }
        }
}
   


