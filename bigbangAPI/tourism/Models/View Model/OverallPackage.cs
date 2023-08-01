namespace tourismBigBang.Models.View_Model
{
    public class OverallPackage
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; } = string.Empty;
        public int Activities { get; set; }
        public int Hotel { get; set; }

    }
}
