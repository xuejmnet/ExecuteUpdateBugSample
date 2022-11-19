using Microsoft.EntityFrameworkCore;

namespace ExcuteUpdateBugSample;

public static class QueryableExtension
{
    public static int LogicDelete<T>(this IQueryable<T> queryable) where T:ILogicDelete
    {
        return queryable.ExecuteUpdate(o => o.SetProperty(p => p.IsDelete, p => true));
    }
}