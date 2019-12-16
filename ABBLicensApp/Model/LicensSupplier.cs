namespace ABBLicensApp.Model
{
    public class LicensSupplier : Supplier
    {
        public LicensSupplier(string name) : base(name)
        {
            Type = "Licens";
            
        }

        public LicensSupplier()
        {
            Type = "Licens";
        }

        public string Type { get; set; }
    }
}
