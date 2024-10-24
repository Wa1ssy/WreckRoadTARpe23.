namespace WreckRoad.Models.Cars
{
    public enum CarType
    {
        Honda, BMW, Audi, Mercedes, Toyota, Lamborghini, Porsche, Ferrari, Ford, Mitsubishi, Volvo, Saab, Unknown
    }

    public enum CarStatus
    {
        Alive, Crashed, Riding
    }
    public class CarIndexViewModel
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
        public DateTime CarWasBuilt { get; set; }
        public DateTime CarCrashed { get; set; }

        //db only
        public DateTime BuiltAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
