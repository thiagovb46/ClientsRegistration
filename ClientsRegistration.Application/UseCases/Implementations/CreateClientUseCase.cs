using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.ExternalServices.Interfaces;
using ClientsRegistration.Application.UseCases.Interfaces;
using ClientsRegistration.Model.IRepositories;

namespace ClientsRegistration.Application.UseCases.Implementations
{
    public class CreateClientUseCase : ICreateClientUseCase
    {
        private readonly IClientsRepository _repository;
        private readonly IClientConverter _converter;
        private readonly ICepService _cepService;

        public CreateClientUseCase(IClientsRepository repository, IClientConverter converter, ICepService cepService)
        {
            _repository = repository;
            _converter = converter;
            _cepService = cepService;
        }
        public async Task<ClientResponseDto> Create(ClientRequestDto dto)
        {
            var clientExists = await _repository.ClientExists(_converter.Convert(dto));
            if (clientExists)
                throw new Exception("Já existe um cliente cadastrado com esse cpf ou cnpj ou E-mail");

            dto.Address = await _cepService.VerifyAddress(dto.Address);
            var newClient = _converter.Convert(dto);
            return _converter.Convert(await _repository.Create(newClient));
        }
    }
}
