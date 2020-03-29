using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ComputerStore.Lib.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Messages = new HashSet<Message>();
        }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
