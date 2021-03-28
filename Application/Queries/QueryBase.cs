namespace Application.Queries
{
    public abstract class QueryBase
    {
		public int PageNumber { get; set; }

		public int PageSize { get; set; } = 10;

	}
}