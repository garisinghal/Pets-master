namespace Pets.Domain
{
    public class Pet
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Type);
        }
    }
}
