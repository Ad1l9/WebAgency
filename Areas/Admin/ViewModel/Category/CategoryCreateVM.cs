using System.ComponentModel.DataAnnotations;

namespace AgencyWebSite.Areas.Admin.ViewModel
{
    public class CategoryCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
