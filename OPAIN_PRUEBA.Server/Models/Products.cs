using System.ComponentModel.DataAnnotations;

namespace OPAIN_PRUEBA.Server.Models
{
    public class Products
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public DateTime? CREATEDAT { get; set; }
    }
}
