using foci.Pages;

namespace foci.Models
{
    public class Stats
    {
        public string CsapataNev {  get; set; }
        
        public int JatszottMerkozesekSzama { get; set; }
        public int GyozelmekSzama { get; set; }
        public int DontetlenekSzama { get; set; }
        public int VersegekSzama { get; set; }
        public int Pontszam { get => GyozelmekSzama * 3 + DontetlenekSzama; }
        public int LottGolokSzama { get; set; }
        public int KapottGolokSZama { get; set; }

    }
}
