namespace Catalog.Core.Specifications
{
    public class Pagination<T> where T : class
    {
         public Pagination(){ }

        public Pagination(int pageIndex, int pageSize, long count, IReadOnlyList<T> items)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Items = items;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set;}
        public long Count { get; set; }
        public IReadOnlyList<T> Items { get; set; }
    }
}