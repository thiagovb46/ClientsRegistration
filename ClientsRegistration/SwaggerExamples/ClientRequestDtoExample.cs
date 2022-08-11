using ClientsRegistration.Application.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace ClientsRegistration.Api.SwaggerExamples
{
    public class ClientRequestDtoExample : IExamplesProvider<ClientRequestDto>

    {

        public ClientRequestDto GetExamples()

        {

            return new ClientRequestDto().GetExamples();

        }

    }
}
