using foci.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace foci.Pages
{
    public class MeccsStatsModel : PageModel
    {
        public void OnGet()
        {

        }

        private readonly foci.Models.FociDBContext _context;
        public IList<Meccs> Meccs { get; set; } = default!;
        public List<Stats> Stats { get; set; } = default!;

        public List<String> CsapatokNevei { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Meccs = await _context.Meccsek.ToListAsync();



     
        }
    }
}
