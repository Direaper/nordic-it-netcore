namespace Demo_WebApp.Models
{
    public class PatchCityModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPoi { get; set; }
        
        public PatchCityModel()
        {

        }
        public PatchCityModel( string name, string desc, int numberOfPoi)
        {
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
    }
}
