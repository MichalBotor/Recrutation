using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RekrutacjaProfisys.Entities;

namespace RekrutacjaProfisys.Pages
{
    public class ShowItemsModel : PageModel
    {
        private readonly Model _context;

        public ShowItemsModel (Model context)
        {
            _context = context;
        }
        public IList <DocumentItems> DokumentItems1 { get; set; }
        
        public void OnGet(string Id)
        {
       
            var wszystkie_wiadomosci = from p in _context.DocumentItems select p;
        
            
            wszystkie_wiadomosci = wszystkie_wiadomosci.Where(d => d.DocumentId == Id);
            DokumentItems1 = wszystkie_wiadomosci.ToList();



           
        }
    }
}
