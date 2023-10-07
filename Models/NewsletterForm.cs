using System.ComponentModel.DataAnnotations;

namespace CMS_Assignment.Models;

public class NewsletterForm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public string? RedirectUrl { get; set; } = "/";
}
