namespace WreckRoad.Models.Cities
{
    public class CreateViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int CarLevelRequirement { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();
    }
}
