namespace Domain
{
    public class Couple
    {
        public int Id { get; set; }

        public virtual Engaged Engaged1 { get; set; }
        public virtual Engaged Engaged2 { get; set; }
}
}
