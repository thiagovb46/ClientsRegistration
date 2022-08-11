using ClientsRegistration.Application.Dto;

namespace ClientsRegistration.Application.UseCases.Interfaces
{
    public interface IGetClientUseCase
    {
        Task<ClientResponseDto> Get(int id);
    }
}
