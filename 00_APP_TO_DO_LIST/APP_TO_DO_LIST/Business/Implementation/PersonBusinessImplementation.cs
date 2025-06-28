using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using System.Linq;
using System.Text.RegularExpressions;
namespace APP_TO_DO_LIST.Business.Implementation;

public class PersonBusinessImplementation : IPersonBusiness
{
    private readonly IPersonRepository _repository; // declaração de um campo privado, so pode ser auterado no construtor
    private readonly IAdressRepository _adressRepository; // declaração de um campo privado, so pode ser auterado no construtor
    public PersonBusinessImplementation(IPersonRepository repository, IAdressRepository adressRepository) // constructor
    {
        _repository = repository;
        _adressRepository = adressRepository;
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
      

        //senao 
        //voce cadastra o endereço, pega o id que retornar e set o person.AddressId = newAddressId com o eendereço novo
        var address = _adressRepository.GetById(person.AdressId);
        if (address == null)
        {
            var newAdress= person.Adress;
            
            person.AdressId = newAdress.Id;
            
        }

        // roles for address


        // roles for regions

        if (person.Adress.RegionId >= 77)
            {
                throw new Exception("Region must be less than 77");
            }

            // roles for zipcode

            var zipCode = person.Adress?.ZipCode?.ZipCodeNumber;

            var cleanedZipCode = Regex.Replace(zipCode ?? "", "[^0-9]", ""); // elimina o que não for numero

            if (cleanedZipCode.Length != 8)
            {
                throw new Exception("Zip Code Number must contain 8 numeric digits.");
            }







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

            if (person.Age < 18 || person.Age > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(person.Age), ("Age cannot be less than 18 years"));
            };



            return _repository.Create(person);
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

    }



