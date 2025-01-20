using System.Linq.Expressions;
using SqlSugar;
using Volo.Abp.DependencyInjection;

namespace TobaccoDMSystemManagement.Infrastructure.Repositories;

public interface ISqlSugarRepository<TEntity> : ITransientDependency
{
    Task<ISugarQueryable<TEntity>> GetQueryableAsync();
    Task<ISugarQueryable<TEntity>> GetQueryableAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetAsync(string sql, object? whereObj = null);
    Task<TResult> GetAsync<TResult>(string sql, object? whereObj = null);
    Task<TEntity> GetAsync<TPrimaryKey>(TPrimaryKey id);
    Task<List<TEntity>> GetListAsync();
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression);
    Task<List<TEntity>> GetListAsync(string sql, object? whereObj = null);
    Task<List<TResult>> GetListAsync<TResult>(string sql, object? whereObj = null);
    Task<List<TEntity>> GetPageListAsync(
        int pageNumber,
        int pageSize,
        RefAsync<int> totalNumber,
        Expression<Func<TEntity, bool>> whereExpression,
        Expression<Func<TEntity, object>> orderExpression,
        OrderByType orderByType = OrderByType.Asc);

    Task<int> CountAsync();
    
    Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);

    Task<int> CountAsync(string sql, object? whereObj = null);
    
    Task<bool> InsertAsync(List<TEntity> entities);
    
    Task<bool> InsertAsync(TEntity entity);
    
    /// <summary>
    /// 新增后返回自增列
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<int> InsertReturnIdentityAsync(TEntity entity);

    /// <summary>
    /// 所有字段更新
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(TEntity entity);
    
    /// <summary>
    /// 只更新某列
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    Task<bool> UpdateColumnsAsync(TEntity entity, Expression<Func<TEntity, object>> columns);

    /// <summary>
    /// 不更新某列
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    Task<bool> IgnoreColumnsAsync(TEntity entity, Expression<Func<TEntity, object>> columns);

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(List<TEntity> entities);
    
    /// <summary>
    /// 批量更新：只更新某列
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    Task<bool> UpdateColumnsAsync(List<TEntity> entities, Expression<Func<TEntity, object>> columns);

    /// <summary>
    /// 批量更新：不更新某列
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    Task<bool> IgnoreColumnsAsync(List<TEntity> entities, Expression<Func<TEntity, object>> columns);
    
    Task<bool> DeleteAsync(TEntity entity);
    
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// 主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <returns></returns>
    Task<bool> DeleteAsync<TPrimaryKey>(TPrimaryKey id);
    
    /// <summary>
    /// 多个删除
    /// </summary>
    /// <param name="ids">一组主键Id</param>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <returns></returns>
    Task<bool> DeleteAsync<TPrimaryKey>(IEnumerable<TPrimaryKey> ids);

    Task<int> ExecuteCommandAsync(string sql, object? parameters = null);


}

public class SqlSugarRepository<TEntity>(ISqlSugarClient dbClient) : ISqlSugarRepository<TEntity> where TEntity : class, new()
{
    protected ISugarQueryable<TEntity> GetQueryable() => dbClient.Queryable<TEntity>();
    protected ISugarQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression) => dbClient.Queryable<TEntity>().Where(expression);
    
    public Task<ISugarQueryable<TEntity>> GetQueryableAsync()
    {
        return Task.FromResult(GetQueryable());
    }
    
    public Task<ISugarQueryable<TEntity>> GetQueryableAsync(Expression<Func<TEntity, bool>> expression)
    {
        return Task.FromResult(GetQueryable(expression));
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().AnyAsync(expression);
    }

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().FirstAsync(expression);
    }

    public Task<TEntity> GetAsync(string sql, object? whereObj = null)
    {
        return dbClient.Ado.SqlQuerySingleAsync<TEntity>(sql,whereObj);
    }
    
    public Task<TResult> GetAsync<TResult>(string sql, object? whereObj = null)
    {
        return dbClient.Ado.SqlQuerySingleAsync<TResult>(sql,whereObj);
    }

    public Task<TEntity> GetAsync<TPrimaryKey>(TPrimaryKey id)
    {
        return GetQueryable().In(id).FirstAsync();
    }

    public Task<List<TEntity>> GetListAsync()
    {
        return GetQueryable().ToListAsync();
    }
    
    public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().Where(expression).ToListAsync();
    }
    
    public Task<List<TEntity>> GetListAsync(string sql, object? whereObj = null)
    {
        return dbClient.Ado.SqlQueryAsync<TEntity>(sql,whereObj);
    }

    public Task<List<TResult>> GetListAsync<TResult>(string sql, object? whereObj = null)
    {
        return dbClient.Ado.SqlQueryAsync<TResult>(sql,whereObj);
    }

    /// <inheritdoc />
    public Task<List<TEntity>> GetPageListAsync(
        int pageNumber, 
        int pageSize, 
        RefAsync<int> totalNumber,
        Expression<Func<TEntity, bool>> whereExpression,
        Expression<Func<TEntity, object>> orderExpression, 
        OrderByType orderByType = OrderByType.Asc)
    {
        return GetQueryable()
                .Where(whereExpression)
                .OrderBy(orderExpression, orderByType)
                .ToPageListAsync(pageNumber,pageSize,totalNumber);
    }

    public Task<int> CountAsync()
    {
        return GetQueryable().CountAsync();
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().CountAsync(expression);
    }
    
    public Task<int> CountAsync(string sql, object? whereObj = null)
    {
        return dbClient.Ado.SqlQuerySingleAsync<int>(sql,whereObj);
    }
    
    public async Task<bool> InsertAsync(List<TEntity> entities)
    {
        var resultCount = 0;
        if (entities.Count > 10000)
        {
            resultCount = await dbClient.Fastest<TEntity>().BulkCopyAsync(entities);
        }
        else
        {
            resultCount = await dbClient.Insertable(entities).ExecuteCommandAsync();
        }

        return 0 == entities.Count;
    }
    
    public async Task<bool> InsertAsync(TEntity entity)
    {
        var resultCount = await dbClient.Insertable(entity).ExecuteCommandAsync();
        return resultCount == 1;
    }

    public Task<int> InsertReturnIdentityAsync(TEntity entity)
    {
        return dbClient.Insertable(entity).ExecuteReturnIdentityAsync();
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        var resultCount = await dbClient.Updateable(entity).ExecuteCommandAsync();
        return resultCount == 1;
    }
    
    public async Task<bool> UpdateColumnsAsync(TEntity entity,Expression<Func<TEntity, object>> columns)
    {
        var resultCount = await dbClient.Updateable(entity).UpdateColumns(columns).ExecuteCommandAsync();
        return resultCount == 1;
    }
    
    public async Task<bool> IgnoreColumnsAsync(TEntity entity,Expression<Func<TEntity, object>> columns)
    {
        var resultCount = await dbClient.Updateable(entity).IgnoreColumns(columns).ExecuteCommandAsync();
        return resultCount == 1;
    }
    
    public async Task<bool> UpdateAsync(List<TEntity> entities)
    {
        var resultCount = await dbClient.Updateable(entities).ExecuteCommandAsync();
        return resultCount == entities.Count;
    }
    
    public async Task<bool> UpdateColumnsAsync(List<TEntity> entities,Expression<Func<TEntity, object>> columns)
    {
        var resultCount = await dbClient.Updateable(entities).UpdateColumns(columns).ExecuteCommandAsync();
        return resultCount == entities.Count;
    }
    
    public async Task<bool> IgnoreColumnsAsync(List<TEntity> entities,Expression<Func<TEntity, object>> columns)
    {
        var resultCount = await dbClient.Updateable(entities).IgnoreColumns(columns).ExecuteCommandAsync();
        return resultCount == entities.Count;
    }
    
    public async Task<bool> DeleteAsync(TEntity entity)
    {
        var resultCount = await dbClient.Deleteable(entity).ExecuteCommandAsync();
        return resultCount == 1;
    }

    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var resultCount = await dbClient.Deleteable<TEntity>().Where(expression).ExecuteCommandAsync();
        return resultCount > 0;
    }

    public async Task<bool> DeleteAsync<TPrimaryKey>(TPrimaryKey id)
    {
        var resultCount = await dbClient.Deleteable<TEntity>().In(id).ExecuteCommandAsync();
        return resultCount == 1;
    }
    
    public async Task<bool> DeleteAsync<TPrimaryKey>(IEnumerable<TPrimaryKey> ids)
    {
        var resultCount = await dbClient.Deleteable<TEntity>().In(ids.ToArray()).ExecuteCommandAsync();
        return resultCount == ids.Count();
    }

    public Task<int> ExecuteCommandAsync(string sql, object? parameters = null)
    {
        return dbClient.Ado.ExecuteCommandAsync(sql,parameters);
    }

}