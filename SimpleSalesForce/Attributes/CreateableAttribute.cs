using System;

namespace Simple.Salesforce
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CreateableAttribute : Attribute
    {
        public bool Createable { get; private set; }

        public CreateableAttribute(bool createable)
        {
            Createable = createable;
        }
    }
}