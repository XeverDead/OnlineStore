using OnlineStore.Common.Enums;
using OnlineStore.Common.Models.SubModels;
using System.Collections.Generic;

namespace OnlineStore.Common.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public Role Role { get; set; }

        public List<PhoneNumberModel> PhoneNumbers { get; set; }

        public List<EmailModel> Emails { get; set; }
    }
}
