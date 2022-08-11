using ClientsRegistration.Application.Dto;
using ClientsRegistration.Model.Enum;
using ClientsRegistration.Model.Model;

namespace ClientsRegistration.Application.Converters
{
    public class ClientConverter : IClientConverter
    {
        public Client Convert(ClientRequestDto dto)
        {
            if (dto.ClientType.Equals(ClientTypeEnum.fisica))
            {
                return new()
                {
                    Name = dto.Name,
                    Cpf = dto.CPF,
                    PhoneNumbers = FillPhoneNumbers(dto.Phones),
                    Address = FillAddress(dto.Address),
                    Email = dto.Email,
                    Classification = dto.Classification,
                    ClientType = dto.ClientType,
                };
            }
            return new()
            {
                EnterpriseName = dto.Name,
                Cnpj = dto.Cnpj,
                PhoneNumbers = FillPhoneNumbers(dto.Phones),
                Address = FillAddress(dto.Address),
                Email = dto.Email,
                Classification = dto.Classification,
                ClientType = dto.ClientType,
            };

        }
        public ClientResponseDto Convert(Client client)
        {
            return new()
            {
                Name = client.Name,
                EnterpriseName = client.Name,
                CPF = client.Cpf,
                Cnpj = client.Cnpj,
                Phones = FillPhoneNumbers(client.PhoneNumbers),
                Address = FillAddress(client.Address),
                Email = client.Email,
                Classification = client.Classification,
                ClientType = client.ClientType,
            };
        }
        public Client Convert(ClientUpdateRequestDto clientDto, Client client)
        {
            return new()
            {
                PhoneNumbers = FillPhoneNumbers(clientDto.PhoneNumbers),
                Address = FillAddress(clientDto.Address),
                Email = client.Email,
                Classification = client.Classification
            };
        }
        public List<ClientResponseDto> Convert(List<Client> clients)
        {
            List<ClientResponseDto> clientsDto = new();
            foreach (var client in clients)
            {
                clientsDto.Add(new()
                {
                    Name = client.Name,
                    EnterpriseName = client.Name,
                    CPF = client.Cpf,
                    Cnpj = client.Cnpj,
                    Phones = FillPhoneNumbers(client.PhoneNumbers),
                    Address = FillAddress(client.Address),
                    Email = client.Email,
                    Classification = client.Classification,
                    ClientType = client.ClientType,

                });
            };
            return clientsDto;
        }
        private List<PhoneNumber> FillPhoneNumbers(List<PhoneNumberDto> phonesDto)
        {
            List<PhoneNumber> phoneNumbers = new();
            foreach (var phoneNumber in phonesDto)
            {
                phoneNumbers.Add(new()
                {
                    Ddd = phoneNumber.Ddd,
                    Number = phoneNumber.Number,
                });
            }
            return phoneNumbers;
        }
        private List<PhoneNumberDto> FillPhoneNumbers(List<PhoneNumber> phonesDto)
        {
            List<PhoneNumberDto> phoneNumbersDto = new();
            foreach (var phoneNumber in phonesDto)
            {
                phoneNumbersDto.Add(new()
                {
                    Ddd = phoneNumber.Ddd,
                    Number = phoneNumber.Number,
                });
            }
            return phoneNumbersDto;
        }
        public AddressDto FillAddress(Address address)
        {

            return new()
            {
                City = address.City,
                State = address.State,
                Street = address.Street,
                PostalCode = address.PostalCode,
                Neighborhood = address.Neighborhood,
                Number = address.Number,
                Complement = address.Complement
            };
        }
        private Address FillAddress(AddressDto dto)
        {

            return new()
            {
                City = dto.City,
                State = dto.State,
                Street = dto.Street,
                PostalCode = dto.PostalCode,
                Neighborhood = dto.Neighborhood,
                Number = dto.Number,
                Complement = dto.Complement
            };
        }
    }
}
