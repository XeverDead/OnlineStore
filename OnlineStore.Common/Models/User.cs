using System.Collections.Generic;

namespace OnlineStore.Common.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> PhoneNumbers { get; set; }

        public List<string> Emails { get; set; }
    }
}
