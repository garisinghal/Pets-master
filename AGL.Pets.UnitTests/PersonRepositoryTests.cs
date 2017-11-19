using Pets.Domain;
using Pets.UnitTests;
using Pets.Utility.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pets.Utility.Tests
{
    [TestClass()]
    public class PersonRepositoryTests
    {
        [TestMethod()]
        public void SortCatsByOwnerGenderTest_Valid_Success()
        {
            /// ARRANGE
            var context = new TestDataContext
            {
                Persons = new List<Person> {
                    new Person
                    {
                        Gender = "Male",
                        Pets = new List<Pet>
                        {
                            new Pet
                            {
                                Type = "caT",
                                Name = "B",
                            },
                            new Pet
                            {
                                Type = "caT",
                                Name = "A",
                            },
                        }
                    },
                    new Person
                    {
                        Gender = "Female",
                        Pets = new List<Pet>
                        {
                            new Pet
                            {
                                Type = "caT",
                                Name = "C",
                            },
                            new Pet
                            {
                                Type = "whale",
                                Name = "A",
                            },
                            new Pet
                            {
                                Type = "SNAKE",
                                Name = "A",
                            },
                            new Pet
                            {
                                Type = "CATt",
                                Name = "A",
                            },
                        }

                    }
                }.AsQueryable(),
            };
            var respository = new PersonRepository() { Context = context };


            /// ACT
            var items = respository.GetCatsByOwnerGender();

            /// ASSERT
            Assert.IsTrue(items.Count == 2);
            Assert.IsTrue(items.Keys.ToList()[0] == "Male");
            Assert.IsTrue(items["Male"].Count == 2);
            Assert.IsTrue(items["Male"][0].Name == "A");
            Assert.IsTrue(items["Male"][1].Name == "B");
            Assert.IsTrue(items.Keys.ToList()[1] == "Female");
            Assert.IsTrue(items["Female"].Count == 1);
            Assert.IsTrue(items["Female"][0].Name == "C");
        }

        [TestMethod()]
        public void SortCatsByOwnerGenderTest_NullPets_Succeed()
        {
            /// ARRANGE
            var context = new TestDataContext
            {
                Persons = new List<Person> {
                    new Person
                    {
                        Gender = "Female",
                        Pets = null  /// Null pets
                    }
                }.AsQueryable(),
            };
            var respository = new PersonRepository() { Context = context };

            /// ACT
            var items = respository.GetCatsByOwnerGender();

            /// ASSERT
            Assert.IsTrue(items.Count == 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortCatsByOwnerGenderTest_ArgumentNullException()
        {
            /// ARRANGE
            var context = new TestDataContext
            {
                Persons = new List<Person> {
                    new Person
                {
                    Gender = null,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Type = "caT",
                            Name = "A",
                        },
                    }
                },
                }.AsQueryable(),
            };
            var respository = new PersonRepository() { Context = context };

            /// ACT
            var items = respository.GetCatsByOwnerGender();

            /// ASSERT
            Assert.IsTrue(false);
        }
    }
}
