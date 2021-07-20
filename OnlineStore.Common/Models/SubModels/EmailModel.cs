using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Common.Models.SubModels
{
    public class EmailModel
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public int UserId { get; set; }
    }
}
