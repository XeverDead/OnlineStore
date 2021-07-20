using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Common.Models.SubModels
{
    public class PhoneNumberModel
    {
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }
    }
}
