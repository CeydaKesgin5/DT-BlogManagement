namespace Entities.RequestParameters
{
    public class BlogRequestParameters : RequestParameters
    {
        public int? CategoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public BlogRequestParameters() : this(1, 6)
        {

        }
        public BlogRequestParameters(int pageNumber = 1, int pageSize = 6)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
