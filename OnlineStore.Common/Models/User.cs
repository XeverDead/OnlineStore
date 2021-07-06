using OnlineStore.Common.Models.SubModels;
using System.Collections.Generic;

namespace OnlineStore.Common.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<PhoneNumberModel> PhoneNumbers { get; set; }

        public List<EmailModel> Emails { get; set; }
    }
}
