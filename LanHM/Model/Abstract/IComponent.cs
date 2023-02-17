namespace Project.Core.Model
{
    public interface IComponent
    {
        //Domain
        Guid Id { get; set; }
        string? Model { get; set; }
        string? Manufacturer { get; set; }
        string? SerialNumber { get; set; }

        // WMI
        string WmiScope { get; }
        string WmiObjectInitialClass { get; }
        string? WmiUniqueIdPropertyName { get; }
        string[]? WmiObjectAdditionalClasses { get; }
        Dictionary<string, string> WmiFieldsDescription { get; }
    }
}
