using Pets.Common.Interfaces;
using Pets.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Utility.Data
{
    public class FakeDataContext : IDataContext
    {
        public IQueryable<Person> Persons
        {
            get
            {
                return Task.Run(async () => await GetPersons()).Result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IQueryable<Person>> GetPersons()
        {
            var json = string.Empty;
            await Task.Run(() =>
            {
                json = File.ReadAllText(@"Sampledata\persons.json");
            });

            var result = JsonConvert.DeserializeObject<List<Person>>(json);
            return result.AsQueryable();
        }
    }
}
