using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.ExternalServices.Interfaces;
using ClientsRegistration.Application.UseCases.Interfaces;
using ClientsRegistration.Model.IRepositories;
using ClientsRegistration.Model.Model;

namespace ClientsRegistration.Application.UseCases.Implementations
{
    public class UpdateClientUseCase : IUpdateClientUseCase
    {
        private readonly IClientsRepository _repository;
        private readonly IClientConverter _converter;
        private readonly ICepService _cepService;

        public UpdateClientUseCase(IClientsRepository repository, IClientConverter clientConverter, ICepService cepService)
        {
            _repository = repository;
            _converter = clientConverter;
            _cepService = cepService;
        }
        public async Task<ClientResponseDto> Update(int id, ClientUpdateRequestDto dto)
        {
            dto.Address = await _cepService.VerifyAddress(dto.Address);
            var client = await _repository.GetOne(id);
            var emailExists = await _repository.EmailExistsInOtherClient(new Client() { Email = dto.Email, Id = id });
            if (emailExists)
                throw new Exception("Já existe um outro cliente cadastrado com esse E-mail");
            _converter.Convert(dto, client);
            await _repository.SaveChangesAsync();
            return _converter.Convert(client);
        }
    }
}
