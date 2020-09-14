using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();

        Task Adicionar(PersonPhone personPhone);
        Task Atualizar(PersonPhone personPhone);
        Task<IEnumerable<PersonPhone>> GetBusinessEntityID(int businessEntityID);
        Task Remover(PersonPhone personPhone);
    }
}
