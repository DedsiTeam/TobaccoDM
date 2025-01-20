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
        CreateTime = DateTime.Now;
    }

    public string ApplicationName { get; private set; }

    public DateTime CreateTime { get; private set; }

    public void ChangeApplicationName(string newApplicationName)
    {
        ApplicationName = newApplicationName;
    }

    public void CreateUlidTime(Guid Id)
    {
        this.CreateTime= DateTime.Now;
        this.Id = Id;
    }
}