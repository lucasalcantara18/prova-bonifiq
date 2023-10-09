namespace ProvaPub.Models
{
	public class Pagination<T>
    {
		public int TotalCount { get; set; }
		public bool HasNext { get; set; }
        public IEnumerable<T> Itens { get; set; }

        protected Pagination()
        {
            Itens = new List<T>();
        }

        public Pagination(int totalCount, IEnumerable<T> itens)
        {
            TotalCount = totalCount;
            HasNext = false;
            Itens = itens;
        }
    }
}
