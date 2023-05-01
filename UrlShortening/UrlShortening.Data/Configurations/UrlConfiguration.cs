using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UrlShortening.Data
{
    public class UrlConfiguration : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OriginalUrl).HasColumnType("nvarchar(max)");
            builder.Property(x => x.ShortUrl).HasColumnType("nvarchar(50)");

            builder.ToTable("Urls");
        }
    }
}
