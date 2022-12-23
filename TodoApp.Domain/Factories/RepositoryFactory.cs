using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Factories;

public class RepositoryFactory
{
    public static TRepository Create<TRepository>()
        where TRepository : BaseRepository
    {
        var dbContext = DbContextFactory.GetTodoAppDbContext();
        var repositoryInstance = Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository;

        return repositoryInstance!;
    }
}
