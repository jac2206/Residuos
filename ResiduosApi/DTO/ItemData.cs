using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResiduosApi.DTO
{
    public class ItemData
    {

        public string id { get; set; }
        public string productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }

    }
}
