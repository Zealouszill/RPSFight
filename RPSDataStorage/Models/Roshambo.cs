namespace RPSDataStorage.Models
{
    public class Roshambo
    {
        public Roshambo() { }
        public int Id { get; set; }
        public string Country { get; set; }
        public int RockQuantity { get; set; }
        public int PaperQuantity { get; set; }
        public int ScissorQuantity { get; set; }
        public bool Enemy { get; set; }
    }
}