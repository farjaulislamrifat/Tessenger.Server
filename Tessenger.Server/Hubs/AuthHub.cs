using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Tessenger.Server.Algorithoms;
using Tessenger.Server.Data;

namespace Tessenger.Server.Hubs
{
    public class AuthHub : Hub
    {
        public static IHubContext<AuthHub> _AuthHubContext { get; set; }
        public static Dictionary<string, List<string>> User { get; set; } = new();
        public static Dictionary<string, List<string>> GroupUser { get; set; } = new();
        private readonly IDbContextFactory<TessengerServerContext> serverContext;
        IConfiguration configuration { get; set; }
        IAlgorithoms algorithoms { get; set; }
        public AuthHub(IHubContext<AuthHub> context, IDbContextFactory<TessengerServerContext> sc , IAlgorithoms algorithoms, IConfiguration configuration)
        {
            serverContext = sc;
            _AuthHubContext = context;
            this.algorithoms = algorithoms;
            this.configuration = configuration;
        }

        public async void Add(string username, string password)
        {
            username = await algorithoms.Decryption(username, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);
            password = await algorithoms.Decryption(password, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);

            var connectionId = Context.ConnectionId;

            var groups = (await serverContext.CreateDbContextAsync()).Group_Account_Model.ToList();
            var user_ = (await serverContext.CreateDbContextAsync()).User_Account_Model.ToList();
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    if (!GroupUser.Any(c => c.Key == item.Username))
                    {
                        GroupUser.Add(item.Username, new List<string>());
                    }
                }
            }
            var user = user_.FirstOrDefault(c => c.Username == username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    if (User.ContainsKey(username))
                    {
                        User[username].Add(connectionId);
                    }
                    else
                    {
                        User.Add(username, new List<string> { connectionId });
                    }
                }
            }
            var meMemberOrAdmin = groups.Where(c => c.Members_Username.Contains(username) || c.Admin_Usernames.Contains(username)).ToList();
            if (meMemberOrAdmin != null)
            {
                foreach (var item in meMemberOrAdmin)
                {
                    GroupUser[item.Username].Add(connectionId);
                    await _AuthHubContext.Groups.AddToGroupAsync(connectionId, item.Username);

                }
            }
        }

        public override Task OnConnectedAsync()
        {                              
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                var username = User.FirstOrDefault(c => c.Value.Contains(Context.ConnectionId)).Key;
                User[username].Remove(Context.ConnectionId);
                GroupUser[username].Remove(Context.ConnectionId);
                Groups.RemoveFromGroupAsync(Context.ConnectionId, username);
            }
            catch (Exception)
            {

            }
            return base.OnDisconnectedAsync(exception);
        }


    }
}
