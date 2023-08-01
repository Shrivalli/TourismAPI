namespace tourismBigBang.Models.View_Model
{
    public class OverallPackage
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; } = string.Empty;
        public int Activities { get; set; }
        public int Hotel { get; set; }
        public decimal PricePerPerson { get; set; }
        public string? Food { get; set; }
        public string? Iternary { get; set; }
        public int Days { get; set; }
        public string? Image { get; set; }

    }
}
