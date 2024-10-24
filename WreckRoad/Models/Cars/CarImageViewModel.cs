namespace WreckRoad.Models.Cars
{
    public class CarImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image {  get; set; }
        public Guid? CarID { get; set; }
    }
}
