using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Examples.Charge.API;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;

namespace PersonPhones.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;

        public PersonPhoneController(IPersonPhoneFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Response(await _facade.GetBusinessEntityID(id));
        }
            
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonPhoneRequest request)
        {
            return Response(await _facade.Adicionar(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, PersonPhoneRequest request)
        {
            return Response(await _facade.Atualizar(id, request));
        }

        [HttpDelete("{businessEntityID}")]
        public async Task<IActionResult> Excluir(int businessEntityID)
        {
            await _facade.Excluir(businessEntityID);

            return Response();
        }
    }
}
