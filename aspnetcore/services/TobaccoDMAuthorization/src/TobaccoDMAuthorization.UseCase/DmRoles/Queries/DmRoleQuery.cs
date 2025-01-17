using Dedsi.Ddd.Domain.Queries;
using Dedsi.EntityFrameworkCore.Queries;
using TobaccoDMAuthorization.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TobaccoDMAuthorization.DmRoles.Queries;

public interface IDmRoleQuery: IDedsiQuery;

public class DmRoleQuery(IDbContextProvider<TobaccoDMAuthorizationDbContext> dbContextProvider)
    : DedsiEfCoreQuery<TobaccoDMAuthorizationDbContext>(dbContextProvider), IDmRoleQuery;