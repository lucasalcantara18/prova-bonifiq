using ProvaPub.Models;

namespace ProvaPub.Utils
{
    public static class Utils
    {
        public static (List<T> itens, bool hasNext, int totalCount) ObterPaginacao<T>(this IQueryable<T> source, int page)
        {
            var pageSize = 10;
            var totalCount = source.Count();
            var itens = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (itens, page < totalPages, totalCount);
        }

        public static Order NormalizeTimezone(this Order source)
        {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                                                                                            // Em Linux, geralmente: "America/Sao_Paulo"
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(source.OrderDate, timezone);

            source.OrderDate = localTime;

            return source;
        }
    }
}
