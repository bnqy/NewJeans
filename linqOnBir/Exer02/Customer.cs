using System.ComponentModel.DataAnnotations;

namespace Exer02;

public class Customer
{

    [StringLength(5)]
    public string? CustomerId { get; set; }

    [Required]
    [StringLength(40)]
    public string? CompanyName { get; set; }

    [StringLength(30)]
    public string? ContactName { get; set; }

}
