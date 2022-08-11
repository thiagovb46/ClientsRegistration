namespace ClientsRegistration.Application.UseCases.Interfaces
{
    public interface IDeleteClientUseCase
    {
        Task Delete(int id);
    }
}
