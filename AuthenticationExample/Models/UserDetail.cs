using System;
using System.Collections.Generic;

namespace AuthenticationExample.Models
{
    public partial class UserDetail
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? RoleName { get; set; }
    }
}
