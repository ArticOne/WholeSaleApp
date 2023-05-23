using MudBlazor;
using System.Reflection;

namespace WholeSaleApp.Client.Helpers
{
    public class TypeHelper
    {
        public static string GetConstantValue(string fullFieldPath)
        {
            // Split the input string into parts
            string[] parts = fullFieldPath.Split('.');

            try
            {
                Type currentType = typeof(Icons); // start with the outermost class
                for (int i = 1; i < parts.Length - 1; i++) // iterate through the rest of the classes
                {
                    // Get the nested Type object for the current part
                    currentType = currentType.GetNestedType(parts[i], BindingFlags.Public | BindingFlags.NonPublic);
                    if (currentType == null) return null;
                }

                if (currentType != null)
                {
                    // Get the FieldInfo object for the field, which is the last part of the input string
                    var fieldInfo = currentType.GetField(parts[parts.Length - 1]);
                    if (fieldInfo != null)
                    {
                        // Get and return the value of the field
                        return fieldInfo.GetValue(null) as string;
                    }
                }

                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
