using Dedsi.Ddd.Domain.Repositories;
using Dedsi.EntityFrameworkCore.Repositories;
using TobaccoDMAuthorization.DmUsers;
using TobaccoDMAuthorization.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TobaccoDMAuthorization.Repositories.DmUsers;

public interface IDmUserRepository : IDedsiCqrsRepository<DmUser, Guid>;

public class DmUserRepository(IDbContextProvider<TobaccoDMAuthorizationDbContext> dbContextProvider)
    : DedsiCqrsEfCoreRepository<TobaccoDMAuthorizationDbContext, DmUser, Guid>(dbContextProvider),
        IDmUserRepository;