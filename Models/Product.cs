using AgencyWebSite.Models.Base;

namespace AgencyWebSite.Models
{
    public class Product:BaseNameableEntity
    {
        public decimal Price { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
