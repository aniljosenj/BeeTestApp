namespace BeeCore.Entity
{
    public class Bee
    {
        internal virtual int PronounceDeadValue { get; set; } = 0;
        public int Id { get; internal set; }
        public double Health { get; internal set; } = 100;
        public string Type { get; internal set; }
        public bool Dead { get; internal set; }
    }
}
