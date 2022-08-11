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
            var address = await _cepService.CepToAddressDto(dto.Address.PostalCode);
            var newClient = _converter.Convert(dto);
            return _converter.Convert(await _repository.Create(newClient));
        }
    }
}
