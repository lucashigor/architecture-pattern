namespace Domain
{
    public class Engaged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Address MakingOf { get; set; }
    }
}
