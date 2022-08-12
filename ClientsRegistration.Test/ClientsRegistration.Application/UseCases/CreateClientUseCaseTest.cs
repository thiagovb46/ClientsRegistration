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
    public class CreateClientUseCaseTest
    {
        public Mock<IClientsRepository> repositoryMock = new();
        public Mock<ICepService> cepServiceMock = new();
        public Mock<IClientConverter> converterMock = new();

        [Theory]
        [MemberData(nameof(ClientDtoTestDataGenerator))]
        public async void CreateTest(ClientRequestDto clientDto)
        {
            cepServiceMock.Setup(x => x.VerifyAddress(It.IsAny<AddressDto>())).Returns(Task.FromResult(clientDto.Address));
            repositoryMock.Setup(x => x.Create(It.IsAny<Client>())).Returns(Task.FromResult(new Client() { Name = clientDto.Name }));
            converterMock.Setup(x => x.Convert(It.IsAny<ClientRequestDto>())).Returns(new Client() { Name = clientDto.Name, Cpf = clientDto.CPF });
            converterMock.Setup(x => x.Convert(It.IsAny<Client>())).Returns(new ClientResponseDto() { Name = clientDto.Name, CPF = clientDto.CPF });
            //Arrange
            CreateClientUseCase useCase = new(repositoryMock.Object, converterMock.Object, cepServiceMock.Object);

            //Act
            var actual = await useCase.Create(clientDto);
            //Assert
            Assert.Equal(clientDto.Name, actual.Name);
            Assert.Equal(clientDto.CPF, actual.CPF);
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