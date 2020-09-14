using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task Adicionar(PersonPhone personPhone);
        Task Atualizar(int id, PersonPhone personPhone);
        Task<IEnumerable<PersonPhone>> GetBusinessEntityID(int businessEntityID);
        Task Remover(PersonPhone personPhone);
    }
}
