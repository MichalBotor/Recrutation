using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System.ComponentModel.DataAnnotations.Schema;

namespace RekrutacjaProfisys.Entities
{
    public class Dokuments
    {
        
        [Index(0)]
        public string? Id { get; set; }

        [Index(1)]
        public string? Type { get; set; }

        [Index(2)]
        public DateTime? Date { get; set; }

        [Index(3)]
        public string? FirstName { get; set; }

        [Index(4)]
        public string? LastName { get; set; }

        [Index(5)]
        public string? City { get; set; }

       


    }
}
