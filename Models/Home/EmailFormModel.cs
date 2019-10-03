using System.ComponentModel.DataAnnotations;

namespace NetCorePortfolio.Models.Home
{
    public class EmailFormModel
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "The E-mail field is required.")]
        [EmailAddress(ErrorMessage = "The E-mail field is not a valid e-mail address.")]
        public string FromEmailAddress { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
