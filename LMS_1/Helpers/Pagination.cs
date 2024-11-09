namespace LMS_1.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int count, int pageSize, int pageNumber, IEnumerable<T> data)
        {
            Count = count;
            PageSize = pageSize;
            PageNumber = pageNumber;
            Data = data;
        }

        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
