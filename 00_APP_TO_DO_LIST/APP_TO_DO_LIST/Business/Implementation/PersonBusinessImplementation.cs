using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using System.Linq;
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

        return _repository.FindAll(p => p.ToDoLists); // parametro adicionado para incuir ToDoList no person
    }

    public Person GetById(int id)
    {
        return _repository.GetById(id, p => p.ToDoLists);
    }

    public Person Create(Person person)
    {
        //Exist(person);

        if (_repository.Exists(p => p.Name == person.Name))
        {
            throw new ArgumentException($"This person: {person.Name} already exists in the database", nameof(person.Name));
        }

        if (string.IsNullOrEmpty(person.Name))
        {
            throw new ArgumentException("The name of the person should not be empty", nameof(person.Name));
        }
        if (person.Name.Length < 10)
        {
            throw new ArgumentException("The name should have more 10 characters", nameof(person.Name));
        }

        if (person.Age < 18)
        {
            throw new ArgumentOutOfRangeException(nameof(person.Age), ("Age cannot be less than 18 years"));
        }
            ;

        if (!IsValidAddress(person))
        {
            throw new ArgumentException("Complete the address or leave all address fields empty.", nameof(person));
        }
            ;

        return _repository.Create(person);
    }

    private bool IsValidAddress(Person person)
    {
        bool allFieldsFilled = !string.IsNullOrWhiteSpace(person.Street) &&
                               !string.IsNullOrWhiteSpace(person.Number) &&
                               !string.IsNullOrWhiteSpace(person.ZipCode) &&
                               !string.IsNullOrWhiteSpace(person.City) &&
                               !string.IsNullOrWhiteSpace(person.State);

        bool allFieldsEmpty = string.IsNullOrWhiteSpace(person.Street) &&
                              string.IsNullOrWhiteSpace(person.Number) &&
                              string.IsNullOrWhiteSpace(person.ZipCode) &&
                              string.IsNullOrWhiteSpace(person.City) &&
                              string.IsNullOrWhiteSpace(person.State);

        return allFieldsFilled || allFieldsEmpty;
    }

    public Person Update(Person person)
    {
        //passou 1 no Person.Id para buscar se existe alguma tarefa com esse ID
        //retornou o antigo valor agora o antigo valor esta no existingTask
        Person existingPerson = _repository.GetById(person.Id);  // finds the existing person and saves it in the variable
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
        Person result = GetById(id);
        if (result != null)
        {
            _repository.Delete(result);
        }
    }

    //public Person Exist(Person person)
    //{
    //    bool exist = _repository.(p => p.Name == person.Name).Any();

    //    //bool exist = _repository.Any(p => p.Name == person.Name);
    //    if (exist)
    //    {
    //        throw new ArgumentException($"This person: {person.Name} already exists in the database", nameof(person.Name));
    //    }

    //    return person;
}



