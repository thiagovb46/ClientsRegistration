using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.Exceptions;
using ClientsRegistration.Application.ExternalServices.Interfaces;
using Flurl;
using Flurl.Http;

namespace ClientsRegistration.Application.ExternalServices.Implementations
{
    public class CepService : ICepService
    {

        public async Task<AddressDto> VerifyAddress(AddressDto dto)
        {
            var address = await "https://viacep.com.br/ws/"
            .AppendPathSegment(dto.PostalCode)
            .AppendPathSegment("/json")
            .GetJsonAsync<AddressCorreiosDto>();
            if (address == default)
                throw new CepNotFoundException();
            dto.City = address.localidade.Contains(dto.City) ? address.localidade : throw new DifferentAddressException("cidade");
            dto.Street = address.logradouro.Contains(dto.Street) ? address.logradouro : throw new DifferentAddressException("logradouro");
            dto.State = address.uf.Equals(dto.State.ToUpper()) ? address.uf : throw new DifferentAddressException("Estado");
            dto.Neighborhood = address.bairro.Contains(dto.Neighborhood) ? address.bairro : throw new DifferentAddressException("Bairro");
            return dto;
        }
    }
}