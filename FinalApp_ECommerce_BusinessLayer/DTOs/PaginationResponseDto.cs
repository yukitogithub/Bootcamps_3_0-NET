using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_BusinessLayer.DTOs
{
    public class PaginationResponseDto<T>
    {
        public List<T> Data { get; set; }
        public PaginationMetadata Pagination { get; set; }
    }
}
