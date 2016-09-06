using System;
namespace SN
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequestAttribute: Attribute
    {
        private string attr;
        public RequestAttribute(string attrValue)
        {
            this.attr = attrValue;
        }
        public string AttributeValue { get { return attr; } set { attr = value; } }
    }
}
