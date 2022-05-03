using System.ComponentModel.DataAnnotations;

namespace HelloMVC.Models.Person;

/// <summary>
/// Model
/// </summary>
public class UpdatePersonModel
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int? Age { get; set; }
}
