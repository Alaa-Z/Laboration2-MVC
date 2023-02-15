using System.ComponentModel.DataAnnotations;

namespace Laboration2.Models
{
    public class EducationModel
    {
        // Propreties
        [Required]
        public string? University { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "From")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "To")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Duration in years")]
        public string? Duration { get; set; }

        [Required]
        [Display(Name = "Program")]
        public string? Education { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Did you finish it?")]
        public string? Done { get; set; }


        // Extract year
        public string StartYear => DateTime.Parse(StartDate.ToString()).Year.ToString();
        public string EndYear => DateTime.Parse(EndDate.ToString()).Year.ToString();
        // Extract month
        public string StartMonth => DateTime.Parse(StartDate.ToString()).ToString("MMMM");
        public string EndMonth => DateTime.Parse(EndDate.ToString()).ToString("MMMM");

    }
}