using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneResponse> FindAllAsync()
        {
            var result = await _personPhoneService.FindAllAsync();
            var response = new PersonPhoneResponse();
            response.ExampleObjects = new List<PersonPhoneDto>();
            response.ExampleObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }

        public async Task<PersonPhoneResponse> Adicionar(PersonPhoneRequest personPhoneRequest)
        {
            var personPhone = _mapper.Map<PersonPhone>(personPhoneRequest);
            await _personPhoneService.Adicionar(personPhone);

            var response = new PersonPhoneResponse();

            return response;
        }

        public async Task<PersonPhoneResponse> Atualizar(int id, PersonPhoneRequest personPhoneRequest)
        {
            var personPhone = _mapper.Map<PersonPhone>(personPhoneRequest);
            await _personPhoneService.Atualizar(id, personPhone);

            var response = new PersonPhoneResponse();

            return response;
        }

        public async Task<PersonPhoneResponse> GetBusinessEntityID(int businessEntityID)
        {
            var result = await _personPhoneService.GetBusinessEntityID(businessEntityID);
            var response = new PersonPhoneResponse();
            response.ExampleObjects = new List<PersonPhoneDto>();
            response.ExampleObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }

        public async Task Excluir(int businessEntityID)
        {
            var result =  _personPhoneService.GetBusinessEntityID(businessEntityID).Result.FirstOrDefault();

            await _personPhoneService.Remover(result);
        }
    }
}
