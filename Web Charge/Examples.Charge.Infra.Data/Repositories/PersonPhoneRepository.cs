using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);
        public async Task Adicionar(PersonPhone personPhone)
        {
            await _context.PersonPhone.AddAsync(personPhone);
            _context.SaveChanges();
        }

        public async Task Atualizar(PersonPhone personPhone)
        {
            _context.PersonPhone.Update(personPhone);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<PersonPhone>> GetBusinessEntityID(int businessEntityID)
        {
            return await _context.PersonPhone.Where(x => x.BusinessEntityID == businessEntityID).ToListAsync();
        }

        public async Task Remover(PersonPhone personPhone)
        {
            _context.PersonPhone.Remove(personPhone);
            _context.SaveChanges();
        }
    }
}
