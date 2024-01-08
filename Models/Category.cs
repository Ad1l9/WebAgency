using AgencyWebSite.Models.Base;

namespace AgencyWebSite.Models
{
    public class Category:BaseNameableEntity
    {
        public List<Product>? Products { get; set; }
    }
}
