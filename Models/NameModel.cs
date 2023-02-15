using System.ComponentModel.DataAnnotations;

namespace Laboration2.Models
{
    public class NameModel
    {
        // Propreties
        [Required]
        public string? Name { get; set; }

    }
}