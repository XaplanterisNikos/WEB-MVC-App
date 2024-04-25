using System;
using System.Collections.Generic;

namespace UserMVC5App.Models;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
