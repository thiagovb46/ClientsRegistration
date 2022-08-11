using ClientsRegistration.Application.Dto;
using ClientsRegistration.Model.Model;

namespace ClientsRegistration.Application.Converters
{
    public interface IClientConverter
    {
        Client Convert(ClientRequestDto dto);
        ClientResponseDto Convert(Client client);
        List<ClientResponseDto> Convert(List<Client> clients);
        Client Convert(ClientUpdateRequestDto clientDto, Client client);

    }
}
