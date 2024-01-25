using DatabaseIntegration.Entities.Player;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIntegration.Configuration
{
    public class GameCharacterTransformConfiguration : IEntityTypeConfiguration<GameCharacterTransform>
    {
        public void Configure(EntityTypeBuilder<GameCharacterTransform> builder)
        {
            builder.HasKey(gct => gct.Id);

            builder.HasIndex(gct => gct.GameCharacterId);
        }
    }
}
