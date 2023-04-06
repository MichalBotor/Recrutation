using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using RekrutacjaProfisys.Entities;
using CsvHelper.TypeConversion;

namespace RekrutacjaProfisys.Pages
{
    public class ShowEntiesModel : PageModel
    {
        private readonly Model _context;

        public ShowEntiesModel(Model context)
        {
            _context = context;
        }
        public IList<Dokuments> Dokuments { get; set; }
        public void OnGet()
        {
             Dokuments = _context.Dokuments.ToList<Dokuments>();

            

        }

        public class DoubleConverter : CsvHelper.TypeConversion.DoubleConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                {
                    return result;
                }
                return base.ConvertFromString(text, row, memberMapData);
            }
        }
        public sealed class DocumentItemsMapWithoutID : ClassMap<DocumentItems>
        {
            public DocumentItemsMapWithoutID()
            {
                Map(m => m.DocumentId).Index(0);
                Map(m => m.Ordinal).Index(1);
                Map(m => m.Product).Index(2);
                Map(m => m.Quantity).Index(3);
                Map(m => m.Price).Index(4).TypeConverter<DecimalConverter>();
                Map(m => m.TaxRate).Index(5);
 
            }
        }


        public async Task<IActionResult> OnPostAsync()
            {
            _context.Dokuments.RemoveRange(_context.Dokuments);
            var culture = new CultureInfo("pl-Pl");
            var csvConfig = new CsvConfiguration(culture)
                {
                    Delimiter = ";",
                    MissingFieldFound = null,
                    HeaderValidated = null,
                    IgnoreBlankLines = true,
                    

            };
            
            using (var reader = new StreamReader(@"M:\Documents.csv"))
                using (var csv = new CsvReader(reader, new CsvConfiguration(culture) { Delimiter = ";" }))
                {
                

                var records = csv.GetRecords<Dokuments>().ToList();
                var sortedRecords = records.OrderBy(r => r.Id).ToList();

                foreach (var record in sortedRecords)
                    {
                        _context.Dokuments.Add(record);
                    }

                    await _context.SaveChangesAsync();
                }

            _context.DocumentItems.RemoveRange(_context.DocumentItems);
            using (var reader2 = new StreamReader(@"M:\DocumentItems.csv"))
            using (var csv2 = new CsvReader(reader2, new CsvConfiguration(culture) { Delimiter = ";" }))
            {
                
                csv2.Context.RegisterClassMap<DocumentItemsMapWithoutID>(); 
                var records2 = csv2.GetRecords<DocumentItems>().ToList();
                

                foreach (var record2 in records2)

                {   
                    _context.DocumentItems.Add(record2);
                }

                await _context.SaveChangesAsync();
            }


            TempData["Message"] = "Import completed successfully.";
                return RedirectToPage();
            }


        }
    

    

    
}
  


