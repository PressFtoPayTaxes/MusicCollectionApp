namespace LINQ.Models
{
    public class Song : Entity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
        public virtual Performer Performer { get; set; }
    }
}