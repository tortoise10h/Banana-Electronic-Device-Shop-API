namespace api.Common.Enums
{
    public class PaginationDefault
    {
        public static int Page { get; set; } = 1;
        public static int Limit { get; set; } = 10;
        public static string SortName { get; set; } = "CreatedAt";
        public static bool IsAscending { get; set; } = false;
    }
}