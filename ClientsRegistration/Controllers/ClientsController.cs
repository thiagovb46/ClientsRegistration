using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientsRegistration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ICreateClientUseCase _createClientUseCase;
        private readonly IGetAllClientsUseCase _getAllClientsUseCase;
        private readonly IGetClientUseCase _getClientUseCase;
        private readonly IUpdateClientUseCase _updateClientUseCase;
        private readonly IDeleteClientUseCase _deleteClienteUseCase;

        public ClientsController(ICreateClientUseCase createClientUseCase, IGetAllClientsUseCase getAllClientsUseCase,
            IUpdateClientUseCase updateClientUseCase, IDeleteClientUseCase deleteClientUseCase, IGetClientUseCase getClientUseCase)
        {
            _createClientUseCase = createClientUseCase;
            _getAllClientsUseCase = getAllClientsUseCase;
            _getClientUseCase = getClientUseCase;
            _updateClientUseCase = updateClientUseCase;
            _deleteClienteUseCase = deleteClientUseCase;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<ActionResult<List<ClientResponseDto>>> Get()
        {
            var clients = await _getAllClientsUseCase.Get();
            return StatusCode(200, clients);

        }
        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponseDto>> Get(int id)
        {
            var client = await _getClientUseCase.Get(id);
            return StatusCode(200, client);
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<ActionResult<ClientResponseDto>> Post([FromBody] ClientRequestDto clientDto)
        {
            var client = await _createClientUseCase.Create(clientDto);
            return StatusCode(201, client);
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClientResponseDto>> Put(int id, [FromBody] ClientUpdateRequestDto clientDto)
        {
            var client = await _updateClientUseCase.Update(id, clientDto);
            return StatusCode(200, client);
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _deleteClienteUseCase.Delete(id);
            return StatusCode(200);
        }
    }
}
