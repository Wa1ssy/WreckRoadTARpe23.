namespace WreckRoad.Core.Domain
{

    public enum Difficulty
    {
        Eazy, Normal, Hard, Insane
    }

    public class City
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int CarLevelRequirement { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
