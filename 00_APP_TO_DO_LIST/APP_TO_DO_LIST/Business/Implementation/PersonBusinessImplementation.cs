using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using System;

namespace APP_TO_DO_LIST.Business.Implementation;

public class PersonBusinessImplementation : IPersonBusiness
{
    private readonly IPersonRepository _repository; // declaração de um campo privado, so pode ser auterado no construtor
    public PersonBusinessImplementation(IPersonRepository repository) // constructor
    {
        _repository = repository;
    }
    public List<Person> FindAll()
    {
        return _repository.FindAll();
    }

    public Person FindById(int id)
    {
        return _repository.FindById(id);
    }

    public Person Create(Person person)
    {
        if (string.IsNullOrEmpty(person.Name))
        {
            throw new ArgumentException("The name of the person should not be empty", nameof(person.Name));
        }
        else if (person.Name.Length < 10)
        {
            throw new ArgumentException("The name should have more 10 characters", nameof(person.Name));
        }

        if (person.Age < 18)
        {
            throw new ArgumentOutOfRangeException(nameof(person.Age), ("Age cannot be less than 18 years"));
        };
  
        if ((!string.IsNullOrEmpty(person.Street)
            && !string.IsNullOrEmpty(person.Number)
            && !string.IsNullOrEmpty(person.ZipCode)
            && !string.IsNullOrEmpty(person.City)
            && !string.IsNullOrEmpty(person.State))
            ||
            ((string.IsNullOrEmpty(person.Street)
            && string.IsNullOrEmpty(person.Number)
            && string.IsNullOrEmpty(person.ZipCode)
            && string.IsNullOrEmpty(person.City)
            && string.IsNullOrEmpty(person.State))))// não finalizado
        {
            return _repository.Create(person);
        }
        else
        {
            throw new Exception("Complete the address");
        }        
    }


    public Person Update(Person person)
    {
        //passou 1 no Person.Id para buscar se existe alguma tarefa com esse ID
        //retornou o antigo valor agora o antigo valor esta no existingTask
        Person existingPerson = _repository.FindById(person.Id);  // finds the existing person and saves it in the variable
        if (existingPerson == null)
        {
            throw new Exception("Person " + person.Name + " does not exist in database");
        }

        if (string.IsNullOrEmpty(person.Name))
        {
            throw new Exception("The name of the person cannot be empty");
        }

        Person result = _repository.Update(existingPerson, person);

        return result;
    }

    public void Delete(int id)
    {
        Person result = FindById(id);
        if (result != null)
        {
            _repository.Delete(result);
        }
    }
}
