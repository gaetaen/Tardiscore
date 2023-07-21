using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TardiscoreAPI.Model.Identity;

namespace TardiscoreAPI.Model.Identity
{
    public class ApplicationManager : UserManager<ApplicationUser>
    {
        public ApplicationManager(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IUserValidator<ApplicationUser> userValidator,
            IPasswordValidator<ApplicationUser> passwordValidator,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger)
            : base(store, optionsAccessor, passwordHasher, new[] { userValidator }, new[] { passwordValidator }, keyNormalizer, errors, services, logger)
        {
        }

        public async Task<ApplicationUser?> FindByRefreshTokenAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }

            return await Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }
    }
}