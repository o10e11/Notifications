namespace Domain.Configuration;

public class HandlerConfiguration
{
    public string ProviderName { get; init; } = string.Empty;
    public bool IsEnabled { get; init; } = false;
    public int Priority { get; init; }
}
