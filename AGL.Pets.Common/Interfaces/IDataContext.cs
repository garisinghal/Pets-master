using Pets.Domain;
using System.Linq;

namespace Pets.Common.Interfaces
{
    /// <summary>
    /// DataContext interfact
    /// </summary>
    public interface IDataContext
    {
        IQueryable<Person> Persons { get; set; }
    }
}
