using Dedsi.Ddd.Domain.Repositories;
using Dedsi.EntityFrameworkCore.Repositories;
using TobaccoDMAuthorization.DmRoles;
using TobaccoDMAuthorization.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TobaccoDMAuthorization.Repositories.DmRoles;

public interface IDmRoleRepository : IDedsiCqrsRepository<DmRole, Guid>;

public class DmRoleRepository(IDbContextProvider<TobaccoDMAuthorizationDbContext> dbContextProvider)
    : DedsiCqrsEfCoreRepository<TobaccoDMAuthorizationDbContext, DmRole, Guid>(dbContextProvider),
        IDmRoleRepository;