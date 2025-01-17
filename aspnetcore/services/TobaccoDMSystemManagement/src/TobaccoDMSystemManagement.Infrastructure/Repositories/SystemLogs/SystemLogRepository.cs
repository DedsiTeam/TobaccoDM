using SqlSugar;
using TobaccoDMSystemManagement.Domain.SystemLogs;

namespace TobaccoDMSystemManagement.Infrastructure.Repositories.SystemLogs;

public interface ISystemLogRepository : ISqlSugarRepository<SystemLog>;

public class SystemLogRepository(ISqlSugarClient dbClient) : SqlSugarRepository<SystemLog>(dbClient), ISystemLogRepository;