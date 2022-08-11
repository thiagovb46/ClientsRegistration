using ClientsRegistration.Application.Dto;

namespace ClientsRegistration.Application.UseCases.Interfaces
{
    public interface IGetAllClientsUseCase
    {
        Task<List<ClientResponseDto>> Get();
    }
}
