using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using System;

namespace APP_TO_DO_LIST.Business.Implementation;

public class PersonBusinessImplementation : IPersonBusiness
{
    private readonly IRepository<Person> _repository; // declaração de um campo privado, so pode ser auterado no construtor
    public PersonBusinessImplementation(IRepository<Person> repository) // constructor
    {
        _repository = repository;
    }
    public List<Person> FindAll()
    {
        return _repository.FindAll();
    }

    public Person FindById(long id)
    {
        return _repository.FindById(id);
    }

    public Person Create(Person person)
    {
        if (string.IsNullOrEmpty(person.Name ))
        {
            throw new Exception("The name of the person should not be empty");
        }
        return _repository.Create(person);

    }

   
    public Person Update(Person person)
    {
        //passou 1 no Person.Id para buscar se existe alguma tarefa com esse ID
        //retornou o antigo valor agora o antigo valor esta no existingTask
        Person existingPerson = _repository.FindById(person.Id);  // finds the existing task and saves it in the variable
        if (existingPerson == null)
        {
            throw new Exception("Task " + person.Name + " does not exist in database");
        }

        if (string.IsNullOrEmpty(person.Name))
        {
            throw new Exception("The name of the task cannot be empty");
        }

        Person result = _repository.Update(existingPerson, person);

        return result;
    }

    public void Delete(long id)
    {
        Person result = FindById(id);
        if (result != null)
        {
            _repository.Delete(result);
        }
    }
}
