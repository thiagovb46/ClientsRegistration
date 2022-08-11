using ClientsRegistration.Application.UseCases.Interfaces;
using ClientsRegistration.Model.IRepositories;

namespace ClientsRegistration.Application.UseCases.Implementations
{
    public class DeleteClientUseCase : IDeleteClientUseCase
    {
        private readonly IClientsRepository _repository;

        public DeleteClientUseCase(IClientsRepository repository)
        {
            _repository = repository;
        }
        public async Task Delete(int id)
        {
            var client = await _repository.GetOne(id);
            _repository.Delete(client);
        }
    }
}
