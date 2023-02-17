using Project.Core.Helpers;
using Project.Core.Model;

ICollection<PhysicalDisk> storages = ClassFromWMI.CreateFromWmiObject<PhysicalDisk>();
ICollection<RamStick> ram = ClassFromWMI.CreateFromWmiObject<RamStick>();


foreach (IComponent obj in storages)
    Console.WriteLine(obj + "\n");