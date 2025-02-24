using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Command.Domain.Constants.Prices;
using _365Beauty.Command.Domain.Entities.Prices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Prices
{
    public class PriceHistoryConfig : IEntityTypeConfiguration<PriceHistory>
    {
        public void Configure(EntityTypeBuilder<PriceHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(PriceHistoryConst.FIELD_PRICE_ID);
            builder.Property(x => x.SalonServiceId).HasColumnName(BeautySalonServiceConst.FIELD_BEAUTY_SALON_SERVICE_ID);
            builder.Property(x => x.Price).HasColumnName(PriceHistoryConst.FIELD_PRICE);
            builder.Property(x => x.StartDate).HasColumnName(PriceHistoryConst.FIELD_PRICE_START_DATE);
            builder.Property(x => x.EndDate).HasColumnName(PriceHistoryConst.FIELD_PRICE_END_DATE);
            builder.Property(x => x.IsActived).HasColumnName(PriceHistoryConst.FIELD_IS_ACTIVED);
            builder.ToTable(PriceHistoryConst.TABLE_NAME);
        }
    }
}