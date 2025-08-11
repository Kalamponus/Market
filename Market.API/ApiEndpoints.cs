namespace Market.API;

public static class ApiEndpoints
{
    private const string API_BASE = "api";

    public static class Lots
    {
        private const string BASE = $"{API_BASE}/lots";

        public const string Create = BASE;
        public const string Get = BASE + $"{BASE}/{{id:guid}}";
        public const string GetAll = BASE;
        public const string Update = $"{BASE}/{{id:guid}}";
        public const string Delete = $"{BASE}/{{id:guid}}";
    }
}