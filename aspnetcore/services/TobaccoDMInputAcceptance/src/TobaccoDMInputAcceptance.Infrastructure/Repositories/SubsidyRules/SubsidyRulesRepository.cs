using Dedsi.Ddd.Domain.Repositories;
using Dedsi.EntityFrameworkCore.Repositories;
using TobaccoDMInputAcceptance.EntityFrameworkCore;
using TobaccoDMInputAcceptance.SubsidyRules;
using Volo.Abp.EntityFrameworkCore;

namespace TobaccoDMInputAcceptance.Repositories.SubsidyRules;

public interface ISubsidyRulesRepository:IDedsiCqrsRepository<InvestmentRules, Guid>;

public class SubsidyRulesRepository(IDbContextProvider<TobaccoDMInputAcceptanceDbContext> dbContextProvider)
    : DedsiCqrsEfCoreRepository<TobaccoDMInputAcceptanceDbContext, InvestmentRules, Guid>(dbContextProvider), ISubsidyRulesRepository;

