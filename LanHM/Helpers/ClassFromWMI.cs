using System.ComponentModel;
using System.Management;
using System.Reflection;
using System.Runtime.Versioning;

namespace Project.Core.Helpers
{
    [SupportedOSPlatform("windows")]
    public class ClassFromWMI
    {
        public static ICollection<T> CreateFromWmiObject<T>(Dictionary<string, string>? fieldsDescription = null) where T : Model.IComponent
        {
            ICollection<T> objectList = new HashSet<T>();

            // void object of T
            T target = (T)Activator.CreateInstance(typeof(T));

            if (fieldsDescription == null) fieldsDescription = target!.WmiFieldsDescription;

            // Get initial info for wmiClass
            Dictionary<string, List<PropertyData>> wmiObjects
                = GetManagementObjects(target!.WmiScope, target.WmiObjectInitialClass, target.WmiUniqueIdPropertyName);

            // Get additional fields if needed
            if (target.WmiObjectAdditionalClasses!.Count() > 0)
                foreach (string additionalClass in target.WmiObjectAdditionalClasses!)
                    GetManagementObjects(target.WmiScope, additionalClass, target.WmiUniqueIdPropertyName, wmiObjects);

            // foreach wmiObject
            foreach (var pair in wmiObjects)
            {
                // create new object of T
                target = (T)Activator.CreateInstance(typeof(T))!;
                objectList.Add(target);
                FillObject(target, fieldsDescription, pair.Value!);
            }

            return objectList;
        }

        public static Dictionary<string, List<PropertyData>> GetManagementObjects(string[] wmiScopes, string wmiObjectClass, string? uniqueField = null, Dictionary<string, List<PropertyData>>? objectDictionaries = null)
        {
            //First string value is unique value for "WmiUniqueIdPropertyName"
            if (objectDictionaries == null)
                objectDictionaries = new Dictionary<string, List<PropertyData>>();

            ManagementClass? oClass = null;

            foreach(string wmiScope in wmiScopes)
            {
                ManagementObjectCollection? managementObjects = null; 
                try
                {
                    oClass = new ManagementClass(wmiScope + ":" + wmiObjectClass);
                    managementObjects = oClass.GetInstances();
                }
                catch (ManagementException)
                {
                    continue;
                }
                
                if (managementObjects == null) continue;

                foreach (ManagementObject oObject in managementObjects)
                {
                    oObject.GetRelated()

                    if (uniqueField == null) throw new NotImplementedException();

                    string? uniqueKeyValue = oObject.GetPropertyValue(uniqueField).ToString()!.Trim();

                    List<PropertyData> objectDictionary = objectDictionaries!.FirstOrDefault(o => o.Key == uniqueKeyValue).Value;

                    if (objectDictionary == null)
                        objectDictionary = new List<PropertyData>();

                    foreach (var wmiObjectProperty in oObject.Properties)
                    {
                        if (objectDictionary.Any(p => p.Name == wmiObjectProperty.Name)) continue;
                        if (wmiObjectProperty.Value is null) continue;

                        objectDictionary.Add(wmiObjectProperty);
                    }
                    if (!objectDictionaries.Any(od => od.Key == uniqueKeyValue!))
                        objectDictionaries!.Add(uniqueKeyValue!, objectDictionary);
                }
            }

            return objectDictionaries;
        }

        public static T FillObject<T>(T target, Dictionary<string, string> dictionary, List<PropertyData> wmiSource) where T : Model.IComponent
        {
            Type targetType = target.GetType();
            PropertyInfo[] targetObjectProperties = targetType.GetProperties();
            foreach (PropertyInfo property in targetObjectProperties)
            {
                KeyValuePair<string, string> propertyInWMIPair = dictionary.FirstOrDefault(d => d.Key == property.Name);

                string? propertyInWMI = propertyInWMIPair.Value;
                if (propertyInWMI == null) continue;

                PropertyData? wmiProperty = wmiSource.FirstOrDefault(p => p.Name == propertyInWMI);

                if (wmiProperty == null) continue;
                if( wmiProperty.Value == null) continue;



                Convert.ToString(wmiProperty.Value);

                string? wmiPropertyValue = Convert.ToString(wmiProperty.Value);

                if (wmiPropertyValue == null || String.IsNullOrEmpty(wmiPropertyValue)) continue;

                var tc = TypeDescriptor.GetConverter(property.PropertyType).ConvertFrom(wmiPropertyValue);

                property.SetValue(target, tc);
            }
            return target;
        }
    }
}
