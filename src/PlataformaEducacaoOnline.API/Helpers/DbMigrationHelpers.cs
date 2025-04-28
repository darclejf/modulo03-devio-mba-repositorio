using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Autenticacao.Data;
using PlataformaEducacaoOnline.Core.Constants;
using System.Security.Claims;

namespace PlataformaEducacaoOnline.API.Helpers
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }
    }
    
    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>();

            var context = scope.ServiceProvider.GetRequiredService<AutenticacaoDbContext>();

            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
            {
                await context.Database.MigrateAsync();

                await EnsureSeedAdmin(context, roleManager, userManager);
            }

        }
        private static async Task EnsureSeedAdmin(AutenticacaoDbContext context, RoleManager<IdentityRole<Guid>> roleManager, UserManager<IdentityUser<Guid>> userManager)
        {
            if (context.Users.Any())
                return;

            // Seed Roles
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.ADMINROLE));
                await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.ALUNOROLE));
            }

            // Seed Users
            var userName = "admin@admin.com";
            var adminId = Guid.NewGuid();
            if (!context.Users.Any(u => u.UserName == userName))
            {
                var adminUser = new IdentityUser<Guid>
                {
                    Id = adminId,
                    UserName = userName,
                    NormalizedUserName = userName.ToUpper(),
                    Email = userName,
                    NormalizedEmail = userName.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                adminUser.PasswordHash = userManager.PasswordHasher.HashPassword(adminUser, "Admin@123");

                await userManager.CreateAsync(adminUser);
                await userManager.AddToRoleAsync(adminUser, Roles.ADMINROLE);                
                await userManager.AddClaimsAsync(adminUser,
                    new List<Claim>() {
                        //new Claim(ClaimName.Categoria, $"{ClaimValue.Cadastrar},{ClaimValue.Editar},{ClaimValue.Excluir}", ClaimValueTypes.String),
                        //new Claim(ClaimName.Orcamento, $"{ClaimValue.Cadastrar},{ClaimValue.Editar},{ClaimValue.Excluir}", ClaimValueTypes.String),
                        //new Claim(ClaimName.Transacao, $"{ClaimValue.Cadastrar},{ClaimValue.Editar},{ClaimValue.Excluir}", ClaimValueTypes.String)
                    });
            }

            //await context.Usuarios.AddAsync(new Usuario(adminId, "Admin User", "admin@teste.com"));

            await context.SaveChangesAsync();
        }
    }
}
