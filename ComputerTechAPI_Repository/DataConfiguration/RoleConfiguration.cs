using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.DataConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
         builder.HasData(
         new IdentityRole
         {
             Name = "ApiManager",
             NormalizedName = "APIMANAGER"
         },
         new IdentityRole
         {
             Name = "User",
             NormalizedName = "USER"
         }
         );
    }
}
