using System;

namespace api.Helpers
{
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
        public string UploadDir { get; set; }
        public string ShopEmail { get; set; }
        public string ShopEmailPassword { get; set; }
    }
}