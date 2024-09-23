using foci.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace foci.Pages
{
    public class AdatokFeltolteseModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly FociDBContext _context;

        public AdatokFeltolteseModel(IWebHostEnvironment env, FociDBContext context)
        {
            _env = env;
            _context = context;
        }

        [BindProperty]
        public IFormFile Feltoltes {  get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var UploadDirPath = Path.Combine(_env.ContentRootPath, "uploads");
            var UploadFilePath = Path.Combine(UploadDirPath, Feltoltes.FileName);
            using (var stream = new FileStream(UploadFilePath, FileMode.Create)) 
            { 
                await Feltoltes.CopyToAsync(stream);
            }

            StreamReader sr = new StreamReader(UploadFilePath);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var elemek = line.Split();
                Meccs ujMeccs = new Meccs();
                ujMeccs.Fordulo = int.Parse(elemek[0]);
                ujMeccs.HazaiFelido = int.Parse(elemek[1]);
                ujMeccs.VendegFelido = int.Parse(elemek[2]);
                ujMeccs.HazaiVeg = int.Parse(elemek[3]);
                ujMeccs.VendegVeg = int.Parse(elemek[4]);
                ujMeccs.HazaiNev = elemek[5];
                ujMeccs.VendegNev = elemek[6];

                if (!_context.Meccsek.Contains(ujMeccs))
                {
                    _context.Meccsek.Add(ujMeccs);
                }
                
            }

            sr.Close();
            _context.SaveChanges();
            System.IO.File.Delete(UploadFilePath);
            return Page();
        }
    }
}
