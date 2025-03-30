using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DefineX.Services.ProductAPI.Models
{
    public class Variant
    {
        [Key]
        public int variant_id { get; set; }
        public int id { get; set; }
        public string sku { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public int image_id { get; set; }

    }
}