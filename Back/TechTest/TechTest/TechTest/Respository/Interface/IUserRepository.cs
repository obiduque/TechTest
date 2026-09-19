namespace TechTest.Respository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<Modelos.User?>> getAllUsers();
        Task createAsync(Modelos.User user);
    }
}
