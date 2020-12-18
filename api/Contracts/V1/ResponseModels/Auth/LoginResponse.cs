using System;
using api.Contracts.V1.ResponseModels.User;

namespace api.Contracts.V1.ResponseModels.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserResponse UserResponse { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpireTime { get; set; }
    }
}