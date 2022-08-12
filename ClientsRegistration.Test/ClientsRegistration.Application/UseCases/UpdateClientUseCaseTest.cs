using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.Dto;
using ClientsRegistration.Application.ExternalServices.Interfaces;
using ClientsRegistration.Application.UseCases.Implementations;
using ClientsRegistration.Model.Enum;
using ClientsRegistration.Model.IRepositories;
using ClientsRegistration.Model.Model;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ClientsRegistration.Test
{
    public class UpdateClientUseCaseTest
    {
        public Mock<IClientsRepository> repositoryMock = new();
        public Mock<ICepService> cepServiceMock = new();
        public Mock<IClientConverter> converterMock = new();

        [Theory]
        [MemberData(nameof(ClientDtoTestDataGenerator))]
        public async void UpdateTest(ClientUpdateRequestDto clientDto)
        {
            converterMock.Setup(x => x.Convert(It.IsAny<ClientUpdateRequestDto>(), It.IsAny<Client>()))
                .Returns(new Client()
                {
                    Email = clientDto.Email,
                    Classification = clientDto.Classification,
                    Address = new()
                    {
                        PostalCode = clientDto.Address.PostalCode
                    }
                });
            converterMock.Setup(x => x.Convert(It.IsAny<Client>()))
                .Returns(new ClientResponseDto()
                {
                    Address = new()
                    {
                        PostalCode = clientDto.Address.PostalCode
                    },
                    Email = clientDto.Email,
                    Classification = clientDto.Classification
                });
            //Arrange
            UpdateClientUseCase useCase = new(repositoryMock.Object, converterMock.Object, cepServiceMock.Object);

            //Act
            var actual = await useCase.Update(1, clientDto);
            //Assert
            Assert.Equal(clientDto.Address.PostalCode, actual.Address.PostalCode);
            Assert.Equal(clientDto.Classification, actual.Classification);
        }
        public static IEnumerable<object[]> ClientDtoTestDataGenerator()
        {
            yield return new object[]
            {
                new ClientUpdateRequestDto()
                {
                    Email = "joaoj@gmail.com",
                    Phones = new PhoneNumberDto().GetExample(),
                    Address = new AddressDto().GetExample(),
                    Classification = ClassificationEnum.Active,
                }

            };
        }
    }

}