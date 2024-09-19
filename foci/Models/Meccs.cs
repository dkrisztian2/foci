namespace foci.Models
{
    public class Meccs
    {
        public int Id { get; set; }
        public int Fordulo { get; set; }    
        public int HazaiFelido { get; set; }
        public int VendegFelido { get; set; }
        public int HazaiVeg { get; set; }
        public int VendegVeg { get; set; }
        public string HazaiNev { get; set; }
        public string VendegNev { get; set; }

        public string GyoztesCsapatNeve() {
            if (HazaiVeg > VendegVeg) {return HazaiNev;}
            else if (HazaiVeg < VendegVeg) { return VendegNev;}
            else return "";
        }

        public int LottGolok(string csapatNev)
        {
            if (csapatNev == HazaiNev) { return HazaiVeg; }
            else if (csapatNev == VendegNev) { return VendegVeg; }
            else return -1;
        }

        public int KapottGolok(string csapatNev)
        {
            if (csapatNev == HazaiNev) { return VendegVeg; }
            else if (csapatNev == VendegNev) { return HazaiVeg; }
            else return -1;
        }


    }
}
