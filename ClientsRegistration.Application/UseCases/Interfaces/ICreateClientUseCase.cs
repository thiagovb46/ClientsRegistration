using ClientsRegistration.Application.Dto;

namespace ClientsRegistration.Application.UseCases.Interfaces
{
    public interface ICreateClientUseCase
    {
        Task<ClientResponseDto> Create(ClientRequestDto dto);
    }
}
