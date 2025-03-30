using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DefineX.Services.ProductAPI.Models
{
    public class Image
    {
        [Key]
        public int image_id { get; set; }
        public int id { get; set; }
        public string alt { get; set; }
        public string src { get; set; }
        public int[] variant_id { get; set; }
    }
}