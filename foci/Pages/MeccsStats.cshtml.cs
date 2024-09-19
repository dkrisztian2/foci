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

        private readonly FociDBContext _context;
        public MeccsStatsModel(FociDBContext context)
        {
            _context = context;
        }
        public List<Meccs> meccsek;
        public List<Stats> stats = new List<Stats>();

        public void OnGet()
        {
            meccsek = _context.Meccsek.ToList();

            var hazaiak = meccsek.Select(x => x.HazaiNev).Distinct().ToList();
            var vendegek = meccsek.Select(x => x.VendegNev).Distinct().ToList();
            List<string> osszes = new List<string>();
            foreach (var v in hazaiak) { osszes.Add(v); }
            foreach (var v in vendegek) { osszes.Add(v); }
            osszes = osszes.Distinct().ToList();



            foreach (var c in osszes) 
            {
                Stats ujcsapat = new Stats();
                ujcsapat.CsapataNev = c;
                stats.Add(ujcsapat);
            }
            foreach (var c in stats)
            {
                c.GyozelmekSzama = meccsek.Count(x => x.GyoztesCsapatNeve() == c.CsapataNev);
                c.DontetlenekSzama = meccsek.Count(x => x.GyoztesCsapatNeve() == "");
                c.VersegekSzama = meccsek.Count(x => x.GyoztesCsapatNeve() != "" && x.GyoztesCsapatNeve() != c.CsapataNev);
                foreach (var item in meccsek)
                {
                    c.LottGolokSzama += item.LottGolok(c.CsapataNev);
                    c.KapottGolokSZama += item.KapottGolok(c.CsapataNev);
                }
                c.JatszottMerkozesekSzama = meccsek.Count(x => x.HazaiNev == c.CsapataNev || x.VendegNev == c.CsapataNev);
                //...

                stats = stats.OrderByDescending(c => c.Pontszam).OrderByDescending(x => x.LottGolokSzama).ToList();
            }
        }

    }
}
