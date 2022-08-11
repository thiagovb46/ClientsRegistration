using ClientsRegistration.Application.Dto;

namespace ClientsRegistration.Application.UseCases.Interfaces
{
    public interface IUpdateClientUseCase
    {
        Task<ClientResponseDto> Update(int id, ClientUpdateRequestDto dto);
    }
}
