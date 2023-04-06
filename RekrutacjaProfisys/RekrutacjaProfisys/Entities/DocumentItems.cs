using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RekrutacjaProfisys.Entities
{
    public class DocumentItems
    {

       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        public string DocumentId { get; set; }

        
        public int Ordinal { get; set; }

        
        public string Product { get; set; }

        
        public int Quantity { get; set; }

        
        public decimal Price { get; set; }

        
        public int TaxRate { get; set; }

        


    }
}
