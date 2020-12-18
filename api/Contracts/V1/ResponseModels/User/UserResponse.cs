using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace api.Contracts.V1.ResponseModels.User
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public string RoleName { get; set; }
    }
}