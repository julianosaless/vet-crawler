namespace VetDirectoryTool.Core.Parser.Template
{
    public class PetMedsViewModel
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public object address2 { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string stateCode { get; set; }
        public string countryCode { get; set; }
        public double distance { get; set; }
        public bool hideOnDirectory { get; set; }
    }
}
