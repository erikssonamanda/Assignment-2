using OAuth2Fb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2Fb.Data
{
    public interface IFacebookService
    {
        Task<Account> GetAccountAsync(string accessToken);
        Task PostOnWallAsync(string accessToken, string message);
    }

    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;
        private Facebook.FacebookClient client;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public FacebookService(Facebook.FacebookClient client)
        {
            this.client = client;
        }

        public async Task<Account> GetAccountAsync(string accessToken)
        {
            var result = await _facebookClient.GetAsync<dynamic>(
                accessToken, "me", "fields=id,first_name,last_name,email,profile_pic");

            if (result == null)
            {
                return new Account();
            }

            var account = new Account
            {
                Id = result.id,
                FirstName = result.first_name,
                LastName = result.last_name,
                Email = result.email,
                ProfilePicture = result.profile_picture
            };

            return account;
        }

        public async Task PostOnWallAsync(string accessToken, string message)
            => await _facebookClient.PostAsync(accessToken, "me/feed", new { message });
    }

}
