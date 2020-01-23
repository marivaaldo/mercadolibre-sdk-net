using MercadoLibre.AspNetCore.SDK.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibre.AspNetCore.SDK.Resources
{
    public class UsersResource : MeliResource
    {
        public UsersResource() { }

        public UsersResource(Meli meli) : base(meli) { }

        public async Task<User> GetUserAsync()
        {
            return await Meli.GetAsync<User>($"/users/{Meli.AuthorizeToken.UserId}");
        }

        public async Task<User> GetUserAsync(long userId)
        {
            return await Meli.GetAsync<User>($"/users/{userId}");
        }
    }
}
