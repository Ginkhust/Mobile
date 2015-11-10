using System;
using Parse;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminControl.Models;
using System.Threading.Tasks;

namespace AdminControl.Provider
{
    public class GetUser
    {
        public async Task<List<Role>> GetRoleOfUser(string username)
        {
            ParseQuery<ParseUser> query = ParseUser.Query.WhereEqualTo("username", username);
            IEnumerable<ParseUser> _users = await query.FindAsync();
            List<Role> roles = new List<Role>();

            foreach (ParseUser p in _users)
            {
                Role r = new Role();
                r.role = p.Get<string>("role");
                roles.Add(r);
            }
            return roles;
        }

    }
}