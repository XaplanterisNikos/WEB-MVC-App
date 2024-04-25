using System;
using System.Collections.Generic;

namespace UserMVC5App.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Institution { get; set; }

    public string? UserRole { get; set; }

    public virtual Student? Student { get; set; }
}
