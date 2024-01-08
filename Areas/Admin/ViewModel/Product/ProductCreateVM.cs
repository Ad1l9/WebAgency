using System.ComponentModel.DataAnnotations;

namespace AgencyWebSite.Areas.Admin.ViewModel
{
    public class ProductCreateVM
    {
        [Required]
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
