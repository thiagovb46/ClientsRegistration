using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.UseCases.Interfaces;
using ClientsRegistration.Model.IRepositories;

namespace ClientsRegistration.Application.UseCases.Implementations
{
    public class GetAllClientsUseCase : IGetAllClientsUseCase
    {
        private readonly IClientsRepository _repository;
        private readonly IClientConverter _converter;

        public GetAllClientsUseCase(IClientsRepository repository, IClientConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public async Task<List<ClientResponseDto>> Get()
        {
            return _converter.Convert(await _repository.GetAll());
        }
    }
}
