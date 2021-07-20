using OnlineStore.Common.Enums;
using OnlineStore.Common.Models.SubModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Common.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        public Role Role { get; set; }

        public List<PhoneNumberModel> PhoneNumbers { get; set; }

        public List<EmailModel> Emails { get; set; }
    }
}
