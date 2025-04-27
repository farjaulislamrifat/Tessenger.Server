using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Tessenger.Server.Algorithoms;
using Tessenger.Server.Data;
using Tessenger.Server.Users_Identity;

namespace Tessenger.Server.Hubs
{
    public class AuthHub : Hub
    {
        public static IHubContext<AuthHub> _AuthHubContext { get; set; }

        private readonly IDbContextFactory<TessengerServerContext> serverContext;
        IConfiguration configuration { get; set; }
        IAlgorithoms algorithoms { get; set; }
        public AuthHub(IHubContext<AuthHub> context, IDbContextFactory<TessengerServerContext> sc, IAlgorithoms algorithoms, IConfiguration configuration)
        {
            serverContext = sc;
            _AuthHubContext = context;
            this.algorithoms = algorithoms;
            this.configuration = configuration;
        }

        public async void Add(string username, string password)
        {

            var connectionId = Context.ConnectionId;

            var groups = (await serverContext.CreateDbContextAsync()).Group_Account_Model.ToList();
            var user_ = (await serverContext.CreateDbContextAsync()).User_Account_Model.ToList();
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    if (!Group_UsernameMembers.Groups.Any(c => c.Key == item.Username))
                    {
                        Group_UsernameMembers.Groups.Add(item.Username, new List<string>());
                    }
                }
            }
            var user = user_.FirstOrDefault(c => c.Username == username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    if (User_Usernames_By_Connection.Users.ContainsKey(username))
                    {
                        User_Usernames_By_Connection.Users[username].Add(connectionId);
                    }
                    else
                    {
                        User_Usernames_By_Connection.Users.Add(username, new List<string> { connectionId });
                    }
                }
            }
            var meMemberOrAdmin = groups.Where(c => c.Members_Username.Contains(username) || c.Admin_Usernames.Contains(username)).ToList();
            if (meMemberOrAdmin != null)
            {
                foreach (var item in meMemberOrAdmin)
                {
                    Group_UsernameMembers.Groups[item.Username].Add(connectionId);
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
                
                     var username = User_Usernames_By_Connection.Users.FirstOrDefault(c => c.Value.Contains(Context.ConnectionId)).Key;
                     User_Usernames_By_Connection.Users[username].Remove(Context.ConnectionId);
                     foreach (var item in Group_UsernameMembers.Groups)
                     {
                         Group_UsernameMembers.Groups[item.Key].Remove(Context.ConnectionId);
                         Groups.RemoveFromGroupAsync(Context.ConnectionId, item.Key);
                     }
             
            }
            catch (Exception)
            {

            }
            return base.OnDisconnectedAsync(exception);
        }





    }
}
