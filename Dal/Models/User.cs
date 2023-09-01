using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dal.Models;

public class User
{
    [DisplayName("Numéro")]
    public int Id { get; set; }

    [DisplayName("Nom")]
    [Required(ErrorMessage = "Le nom est obligatoire")]
    [MinLength(2, ErrorMessage = "Le nom doit faire au moins 2 caractères")]
    public string? Name { get; set; } = string.Empty;
}