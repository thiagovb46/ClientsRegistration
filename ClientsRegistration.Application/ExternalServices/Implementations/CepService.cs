using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.Exceptions;
using ClientsRegistration.Application.ExternalServices.Interfaces;
using Flurl;
using Flurl.Http;

namespace ClientsRegistration.Application.ExternalServices.Implementations
{
    public class CepService : ICepService
    {

        public async Task<AddressDto> CepToAddressDto(string cep)
        {
            var address = await "https://viacep.com.br/ws/"
            .AppendPathSegment(cep)
            .AppendPathSegment("/json")
            .GetJsonAsync<AddressCorreiosDto>();
            if (address == default)
                new CepNotFoundException();

            return new()
            {
                City = address.localidade,
                Street = address.logradouro,
                State = address.uf,
                Neighborhood = address.bairro,
            };
        }
    }
}