using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.ExternalServices.Interfaces;
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

            converterMock.Setup(con => con.Convert(It.IsAny<ClientRequestDto>()))
                .Returns((Client c) => c);
        }
        [Theory]
        [MemberData(nameof(ClientDtoTestDataGenerator))]
        public void CreateTest(ClientRequestDto clientDto)
        {
            //Arrange
            //Act
            //Assert

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