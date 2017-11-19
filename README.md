# Pets
INSTRUCTIONS

1. Download solution and required Nuget packages

3. Build solution

4. Execute all the projects -> Utiltiy Project, Unit Tests project, Web Project

5. Navigate to the PetsTest.html page to run the JavaScript unit tests

SOLUTION DESCRIPTION

The solution consists of 5 projects.

1. Pets.Common contains interfaces used for dependency injection.
 
2. Pets.Domain contains two classes (Person, Pet) used to deserialize the Json data.
 
3. Pets.UnitTests contains tests for the PersonsRepository.GetPets.
 
4. Pets.Utiltity is a Windows Console app project. 
This project defines a PersonRepository class which is used to list Pets in the requested structure described by the coding challenge.

5. A web project to demonstrate a testable JavaScript version

The Utiltity project also defines a DataContext class that is used by the repository to retrieve data. This DataContext class is an implementation of an IDataContext class which is injected (using Property Injection and the Castle Window IoC framework).
The concrete implementations of IDataContext includes a version which does not download Json data from the API service called FakeDataContext. This is useful for debugging, so the WindowsInstaller defines this as the concrete class for IDataContext given a pre-compiler directive of DEBUG.

Three Unit Tests target the PersonReporitoy method GetCatsByOwnerGender. The tests cover three cases:

1. Valid data and successful execution

2. Border case valid data and successful execution

3. Invalid data with an expected exception
