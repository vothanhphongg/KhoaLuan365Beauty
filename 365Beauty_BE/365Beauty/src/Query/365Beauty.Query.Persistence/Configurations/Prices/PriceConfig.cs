using _365Beauty.Query.Domain.Constants.BeautySalons;
using _365Beauty.Query.Domain.Constants.Prices;
using _365Beauty.Query.Domain.Entities.Prices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Prices
{
    public class PriceConfig : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(PriceConst.FIELD_PRICE_ID);
            builder.Property(x => x.SalonServiceId).HasColumnName(BeautySalonServiceConst.FIELD_BEAUTY_SALON_SERVICE_ID);
            builder.Property(x => x.BasePrice).HasColumnName(PriceConst.FIELD_BASE_PRICE);
            builder.Property(x => x.FinalPrice).HasColumnName(PriceConst.FIELD_FINAL_PRICE);
            builder.Property(x => x.CreatedDate).HasColumnName(PriceConst.FIELD_PRICE_CREATED_DATE);
            builder.Property(x => x.IsActived).HasColumnName(PriceConst.FIELD_IS_ACTIVED);
            builder.ToTable(PriceConst.TABLE_NAME);
        }
    }
}