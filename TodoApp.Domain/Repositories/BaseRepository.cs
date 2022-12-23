using TodoApp.Data.Entities;
using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Repositories;

public abstract class BaseRepository
{
	protected readonly TodoAppDbContext DbContext;

	protected BaseRepository(TodoAppDbContext dbContext)
	{
		DbContext = dbContext;
	}

	protected ResponseResultType SaveChanges()
	{
		var hasChanges = DbContext.SaveChanges() > 0;
		if (hasChanges)
			return ResponseResultType.Success;

		return ResponseResultType.NoChanges;
	}
}
