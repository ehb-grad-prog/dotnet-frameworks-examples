using System.ComponentModel.DataAnnotations;

namespace HelloMVC.Models.Person;

public class CreatePersonModel
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, Range(18, 100)]
    public int Age { get; set; }
}
