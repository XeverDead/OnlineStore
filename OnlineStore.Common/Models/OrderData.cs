using OnlineStore.Common.Enums;

namespace OnlineStore.Common.Models
{
    public class OrderData
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public OrderState State { get; set; }
    }
}
