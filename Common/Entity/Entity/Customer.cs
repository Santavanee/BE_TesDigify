using System;
using System.Collections.Generic;

namespace Common.Entity.Entity;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Npwp { get; set; } = null!;

    public string DirectorName { get; set; } = null!;

    public string Picname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public bool AllowAccess { get; set; }

    public string? FileNpwp { get; set; }

    public string? FilePowerOfAttorey { get; set; }
}
