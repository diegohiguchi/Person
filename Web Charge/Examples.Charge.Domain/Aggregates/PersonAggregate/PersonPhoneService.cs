using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task Adicionar(PersonPhone personPhone)
        {
            await _personPhoneRepository.Adicionar(personPhone);
        }

        public async Task Atualizar(int id, PersonPhone personPhone)
        {
            var person = _personPhoneRepository.GetBusinessEntityID(id).Result.FirstOrDefault();
            await _personPhoneRepository.Remover(person);
            await _personPhoneRepository.Adicionar(personPhone);
        }

        public async Task<IEnumerable<PersonPhone>> GetBusinessEntityID(int businessEntityID)
        {
            return await _personPhoneRepository.GetBusinessEntityID(businessEntityID);
        }

        public async Task Remover(PersonPhone personPhone)
        {
            await _personPhoneRepository.Remover(personPhone);
        }
    }
}
