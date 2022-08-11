using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.UseCases.Interfaces;
using ClientsRegistration.Model.IRepositories;

namespace ClientsRegistration.Application.UseCases.Implementations
{
    public class GetClientUseCase : IGetClientUseCase
    {
        private readonly IClientsRepository _repository;
        private readonly IClientConverter _converter;

        public GetClientUseCase(IClientsRepository repository, IClientConverter converter)
        {
            _repository = repository;
            _converter = converter;

        }
        public async Task<ClientResponseDto> Get(int id)
        {
            return (_converter.Convert(await _repository.GetOne(id)));
        }
    }
}
