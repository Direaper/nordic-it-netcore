using System.ComponentModel.DataAnnotations;  //Модуль для правил внесения данных


namespace Demo_WebApp.Models
{
    public class AddCityModel
    {
        [Required] //обязательный параметр
        [MaxLength(100)] //длина 100 символов
        public string Name { get; set; }
        
        [MaxLength(255, ErrorMessage = " Error!")]
        public string Description { get; set; }
        
        [Range(0,100)] //диапазон
        public int NumberOfPoi { get; set; }
        
        public AddCityModel()
        {

        }
        public AddCityModel( string name, string desc, int numberOfPoi)
        {
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
    }
}
