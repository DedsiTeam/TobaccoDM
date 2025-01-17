using Dedsi.CleanArchitecture.Domain;

namespace TobaccoDMAuthorization;

public class TobaccoDMAuthorizationDomainOptions : DedsiCleanArchitectureDomainOptions
{
    public const string ApplicationName = "TobaccoDMAuthorization";
    
    public const string MobileApplicationName = "TobaccoDMAuthorization.Mobile";
    
    public const string ConnectionStringName = "TobaccoDMAuthorizationDB";
    
    public const string DbSchemaName = "dbo";

    public const string DbTablePrefix = "TobaccoDMAuthorization";
}