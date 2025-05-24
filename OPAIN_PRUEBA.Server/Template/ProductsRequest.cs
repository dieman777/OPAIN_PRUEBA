using System.ComponentModel.DataAnnotations;

namespace OPAIN_PRUEBA.Server.Template
{
    public class ProductsRequest
    {
        [Required]
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        [Required]
        public decimal PRICE { get; set; }
    }
}
