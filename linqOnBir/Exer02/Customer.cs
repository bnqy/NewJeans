using System.ComponentModel.DataAnnotations;

namespace Exer02;

public class Customer
{

    [StringLength(5)]
    public string CustomerId { get; set; }

    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; }

    [StringLength(30)]
    public string? ContactName { get; set; }

    [StringLength(30)]
    public string? ContactTitle { get; set; }

    [StringLength(30)]
    public string? Address { get; set; }

    [StringLength(30)]
    public string? City { get; set; }

    [StringLength(30)]
    public string? Region { get; set; }


    [StringLength(30)]
    public string? PostalCode { get; set;}

    [StringLength(30)]
    public string? Country { get; set; }

    [StringLength(30)]
    public string? Phone { get; set; }

    [StringLength(30)]
    public string? Fax { get; set;}

}

