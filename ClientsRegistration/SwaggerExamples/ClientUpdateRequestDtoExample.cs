using ClientsRegistration.Application.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace ClientsRegistration.Api.SwaggerExamples
{
    public class ClientUpdateRequestDtoExample : IExamplesProvider<ClientUpdateRequestDto>

    {
        public ClientUpdateRequestDto GetExamples()

        {

            return new ClientUpdateRequestDto().GetExamples();

        }

    }
}
