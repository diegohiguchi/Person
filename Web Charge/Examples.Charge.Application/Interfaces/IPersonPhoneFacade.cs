using System.Collections.Generic;
using System.Threading.Tasks;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneResponse> FindAllAsync();
        Task<PersonPhoneResponse> Adicionar(PersonPhoneRequest personPhoneRequest);
        Task<PersonPhoneResponse> Atualizar(int id, PersonPhoneRequest personPhoneRequest);
        Task<PersonPhoneResponse> GetBusinessEntityID(int businessEntityID);

        Task Excluir(int businessEntityID);
    }
}