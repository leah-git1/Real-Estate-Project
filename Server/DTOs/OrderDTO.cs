using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record OrderDTO(
        int OrderId,
        DateTime OrderDate,
        decimal TotalPrice,
        string Status,
        DateTime? DeliveryDate,
        List<OrderItemDTO> OrderItems
    );

}
