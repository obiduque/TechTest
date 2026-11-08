namespace TechTest.Respository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<Modelos.User?>> getAllUsers();
        Task<bool> createAsync(Modelos.User user);
    }
}
