using System;
using System.Linq;
namespace SN
{
    public class Controllers
    {
        public static System.Collections.Generic.List<object> Current = new System.Collections.Generic.List<object>();
    }
    public class InvokeByAttribute
    {
        public static dynamic Invoke(string attrval, params object[] parameters)
        {
            foreach (object obj in Controllers.Current)
            {
                try
                {
                    var methodInfo = obj.GetType().GetMethods().
                    Where(x => x.GetCustomAttributes(false).OfType<SN.RequestAttribute>().Count() > 0)
                    .Where(x => x.GetCustomAttributes(false).OfType<SN.RequestAttribute>().First().AttributeValue == attrval)
                    .First();
                    return methodInfo.Invoke(obj, parameters);
                }
                catch (Exception ex) {   return null; }
            }
            return null;
        }
    }
}
