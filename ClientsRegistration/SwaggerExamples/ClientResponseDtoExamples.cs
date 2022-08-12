using ClientsRegistration.Application.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace ClientsRegistration.Api.SwaggerExamples
{
    public class ClientResponseDtoExamples : IExamplesProvider<List<ClientResponseDto>>

    {
        List<ClientResponseDto> clients = new();
        List<ClientResponseDto> IExamplesProvider<List<ClientResponseDto>>.GetExamples()
        {
            clients.Add(new ClientResponseDto().GetExamples());
            return clients;
        }
    }
}
