using System.Collections.Generic;
using Pets.Domain;
using System.Threading.Tasks;

namespace Pets.Common.Interfaces
{
    /// <summary>
    /// General read methods to access the list of Persons.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Get all Persons with Pets as Dictionary with Person's gender as the Key and 
        /// all Pets owned by Persons of that Gender sorted aphabetically as the Value.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, List<Pet>> GetCatsByOwnerGender();
    }
}