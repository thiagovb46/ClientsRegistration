using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientsRegistration.Api.Controllers
{
    [Route("api/clients")]
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
        ///<summary> 
        ///Retorna uma lista com todos os clientes cadastrados
        ///</summary>
        /// <response code="200">Sucesso</response>
        /// <response code="500"> Erro de Servidor.</response> 
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<ActionResult<List<ClientResponseDto>>> Get()
        {
            var clients = await _getAllClientsUseCase.Get();
            return StatusCode(200, clients);

        }
        ///<summary> 
        ///Retorna o cliente com o Id informado pela rota
        ///</summary>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Cliente não encontrado.</response>
        /// <response code="500"> Erro de Servidor.</response> 
        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponseDto>> Get(int id)
        {
            var client = await _getClientUseCase.Get(id);
            return StatusCode(200, client);
        }

        ///<summary> 
        ///Cadastra um novo cliente, que pode ser pessoa física ou jurídica
        ///</summary>
        /// <remarks>
        /// <h3><u>Descrição: Rota para cadastro de clientes, exemplos abaixo</u></h3>
        /// 
        ///<h4><b>Observações: </b> </h4> 
        /// <h4><u> - Campos Obrigatórios para tipoCliente "fisica" : [tipoCliente, cpf, nome, email, telefones, endereco, classificacao]</u></h4>
        /// <h4><u> - Campos Obrigatórios para tipoCliente "juridica" : [tipoCliente, cnpj, razaoSocial, email, telefones, endereco, classificacao]</u></h4>
        /// <h4><u> - OS campos CPF e CNPJ devem ser valores válidos, em caso de testes utilize  um gerador de CPF OU CNPJ, o valor da requisição de exemplo é válido</u></h4>
        /// <h4><u> - O endereço é validado na API dos correios por meio do cep informado, portanto os valores fornecidos devem coincidir exatamente com o retorno da api para um cep ( O endereço da requisição de exemplo é válido)</u></h4>
        /// <h4><b>Valores Validos para enums: </b></h4>
        /// 
        /// tipoCliente :["fisica", "juridica"]
        /// classificacao :["Active", "Inactive", "Preferential"]
        /// 
        /// 
        /// 
        ///</remarks>  
        /// <response code="201">Cliente Cadastrado com sucesso</response>
        /// <response code="400">Problemas no corpo da requisição.</response>
        /// <response code="500"> Erro de Servidor.</response> 
        [HttpPost]
        public async Task<ActionResult<ClientResponseDto>> Post([FromBody] ClientRequestDto clientDto)
        {
            var client = await _createClientUseCase.Create(clientDto);
            return StatusCode(201, client);
        }
        ///<summary> 
        ///Altera as informações de um Cliente com o Id informado pela rota
        ///</summary>
        /// <remarks>
        /// <h3><u>Descrição: Rota para atualização de informações do cliente, atenção, todas as informações do objeto anterior serão substituídas pelas enviadas por essa rota</u></h3>
        /// <h4><b>Observações: </b> </h4> 
        /// <h4>O Put atualiza todos os campos que podem ser atualizados, os campos que não serão alterados precisam ser preenchidos com o valor atual</h4> 
        /// 
        ///<h4><u>Campos que podem ser atualizados: " : [email, telefones, endereco, classificacao]</u></h4>
        /// <h4><u>Campos Obrigatórios" : [email, telefones, endereco, classificacao]</u></h4>
        /// <h4><u> - O endereço é validado na API dos correios por meio do cep informado, portanto os valores fornecidos devem coincidir exatamente com o retorno da api para um cep ( O endereço da requisição de exemplo é válido)</u></h4>
        /// <h4><b>Valores Validos para enums: </b></h4>
        /// 
        /// classificacao :["Active", "Inactive", "Preferential"]
        /// </remarks>  
        /// <response code="200">Cliente Alterado com sucesso</response>
        /// <response code="400">Problemas no corpo da requisição.</response>
        /// <response code="500"> Erro de Servidor.</response> 
        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClientResponseDto>> Put(int id, [FromBody] ClientUpdateRequestDto clientDto)
        {
            var client = await _updateClientUseCase.Update(id, clientDto);
            return StatusCode(200, client);
        }
        ///<summary> 
        ///Apaga do banco de dados um Cliente com o Id informado pela rota
        ///</summary>
        /// <response code="200">Cliente deletado com sucesso</response>
        /// <response code="404">Cliente não encontrado.</response>
        /// <response code="500"> Erro de Servidor.</response> 

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _deleteClienteUseCase.Delete(id);
            return StatusCode(200);
        }
    }
}
