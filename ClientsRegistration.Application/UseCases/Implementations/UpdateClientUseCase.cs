using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.UseCases.Interfaces;
using ClientsRegistration.Model.IRepositories;

namespace ClientsRegistration.Application.UseCases.Implementations
{
    public class UpdateClientUseCase : IUpdateClientUseCase
    {
        private readonly IClientsRepository _repository;
        private readonly IClientConverter _converter;

        public UpdateClientUseCase(IClientsRepository repository, IClientConverter clientConverter)
        {
            _repository = repository;
            _converter = clientConverter;
        }
        public async Task<ClientResponseDto> Update(int id, ClientUpdateRequestDto dto)
        {
            var client = await _repository.GetOne(id);
            _converter.Convert(dto, client);
            await _repository.SaveChangesAsync();
            return _converter.Convert(client);
        }
    }
}
