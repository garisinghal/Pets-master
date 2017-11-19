using Pets.Common.Interfaces;
using Pets.Domain;
using System.Linq;

namespace Pets.UnitTests
{
    public class TestDataContext : IDataContext
    {
        public IQueryable<Person> Persons { get; set; }
    }
}
