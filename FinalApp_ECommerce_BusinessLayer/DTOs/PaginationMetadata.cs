using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_BusinessLayer.DTOs
{
    public class PaginationMetadata
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public bool HasNext { get; set; }
        public string? NextPageUrl { get; set; }
        public bool HasPrevious { get; set; }
        public string? PreviousPageUrl { get; set; }
    }
}
