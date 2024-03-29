using System.ComponentModel;

namespace WebApplication1.Models
{
    public class PaginationModel
    {
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
        public PaginationModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 1 ? 10 : pageSize;
        }
    }
}
