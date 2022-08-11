using ClientsRegistration.Application.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace ClientsRegistration.Api.SwaggerExamples
{
    public class ClientResponseDtoExample : IExamplesProvider<ClientResponseDto>

    {

        public ClientResponseDto GetExamples()

        {

            return new ClientResponseDto().GetExamples();

        }

    }
}
