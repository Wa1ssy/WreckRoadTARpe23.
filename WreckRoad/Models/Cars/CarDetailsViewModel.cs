namespace WreckRoad.Models.Cars
{
    public class CarDetailsViewModel
    {
        public Guid ID { get; set; }
        public string CarName { get; set; }
        public int CarXP { get; set; }
        public int CarXPNextLevel { get; set; }
        public int CarLevel { get; set; }
        public CarType CarType { get; set; }
        public CarStatus CarStatus { get; set; }
        public int TurnSpeed { get; set; }
        public string TurnName { get; set; }
        //public List<IFormFile> Files { get; set; }
        public List<CarImageViewModel> Image { get; set; } = new List<CarImageViewModel>();
    }
}
