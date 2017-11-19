using System.Collections.Generic;

namespace Pets.Domain
{
    public class Person
    {
        public int Age { get; set; }

        public string Gender { get; set; }

        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Gender, Age);
        }
    }
}
