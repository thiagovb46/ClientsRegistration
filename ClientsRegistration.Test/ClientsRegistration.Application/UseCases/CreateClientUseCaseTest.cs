using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.ExternalServices.Interfaces;
using ClientsRegistration.Application.UseCases.Implementations;
using ClientsRegistration.Model.Enum;
using ClientsRegistration.Model.IRepositories;
using ClientsRegistration.Model.Model;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ClientsRegistration.Test
{
    public class CreateClientUseCaseTest
    {
        public Mock<IClientsRepository> repositoryMock = new();
        public Mock<ICepService> cepServiceMock = new();
        public Mock<IClientConverter> converterMock = new();
        public CreateClientUseCaseTest()
        {
            repositoryMock.Setup(repo => repo
            .Create(It.IsAny<Client>()))
                .Returns((Client c) => c);

            cepServiceMock.Setup(cep => cep
            .VerifyAddress(It.IsAny<AddressDto>()))
                .Returns((AddressDto c) => c);
        }
        [Theory]
        [MemberData(nameof(ClientDtoTestDataGenerator))]
        public async void CreateTest(ClientRequestDto clientDto)
        {
            //Arrange
            converterMock.Setup(con => con.Convert(It.IsAny<ClientRequestDto>()))
            .Returns((new Client()
            {
                Cpf = clientDto.CPF,
                Cnpj = clientDto.Cnpj,
                Email = clientDto.Email,
                Name = clientDto.Name,
                Address = new()
                {
                    PostalCode = clientDto.Address.PostalCode,
                }
            }));
            CreateClientUseCase useCase = new(repositoryMock.Object, converterMock.Object, cepServiceMock.Object);
            //Act
            var actual = await useCase.Create(clientDto);
            //Assert
            Assert.Equal(clientDto.CPF, actual.CPF);
            Assert.Equal(clientDto.Cnpj, actual.Cnpj);
            Assert.Equal(clientDto.Email, actual.Email);
            Assert.Equal(clientDto.Name, actual.Name);
            Assert.Equal(clientDto.Address.PostalCode, actual.Address.PostalCode);

        }
        public static IEnumerable<object[]> ClientDtoTestDataGenerator()
        {
            yield return new object[]
            {
                new ClientRequestDto()
                {
                    ClientType = ClientTypeEnum.fisica,
                    CPF = "16876931021",
                    Name = "Joao Silveira",
                    Email = "joaoj@gmail.com",
                    Phones = new PhoneNumberDto().GetExample(),
                    Address = new AddressDto().GetExample(),
                    Classification = ClassificationEnum.Active,
                }

            };
        }
    }

}