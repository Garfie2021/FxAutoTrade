using System.Text;
using System.Reflection;
using System.Collections.Generic;


namespace OANDAv1
{
    public class Response
    {
        private static StringBuilder ToString_result;
        private static IEnumerable<PropertyInfo> ToString_props;
        public override string ToString()
        {
            // use reflection to display all the properties that have non default values
            ToString_result = new StringBuilder();
            ToString_props = this.GetType().GetTypeInfo().DeclaredProperties;
            ToString_result.AppendLine("{");

            foreach (var prop in ToString_props)
            {
                if (prop.Name != "Content" && prop.Name != "Subtitle" && prop.Name != "Title" && prop.Name != "UniqueId")
                {
                    object value = prop.GetValue(this);
                    bool valueIsNull = value == null;
                    object defaultValue = Common.GetDefault(prop.PropertyType);
                    bool defaultValueIsNull = defaultValue == null;

                    if ((valueIsNull != defaultValueIsNull) // one is null when the other isn't
                        || (!valueIsNull && (value.ToString() != defaultValue.ToString()))) // both aren't null, so compare as strings
                    {
                        ToString_result.AppendLine(prop.Name + " : " + prop.GetValue(this));
                    }
                }
            }

            ToString_result.AppendLine("}");

            return ToString_result.ToString();
        }
    }
}
