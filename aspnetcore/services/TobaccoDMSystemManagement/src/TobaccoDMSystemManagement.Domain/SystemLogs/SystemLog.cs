namespace TobaccoDMSystemManagement.Domain.SystemLogs;

public class SystemLog : Entity<Guid>
{
    public SystemLog()
    {
        
    }
    
    public SystemLog(Guid id, string applicationName)
    {
        Id = id;
        ApplicationName = applicationName;
    }

    public string ApplicationName { get; private set; }

    public void ChangeApplicationName(string newApplicationName)
    {
        ApplicationName = newApplicationName;
    }
}