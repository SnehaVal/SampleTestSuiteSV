using System.Configuration;

namespace Framework.Selenium.Configuration
{
    public class DriverArgumentsCollection : ConfigurationElementCollection
    {
        public DriverArgumentsCollection() { }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DriverArgument();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DriverArgument)element).Value;
        }

        public DriverArgument this[int index]
        {
            get
            {
                return (DriverArgument)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(DriverArgument argument)
        {
            BaseAdd(argument);
        }
        public void Clear()
        {
            BaseClear();
        }
        public void Remove(DriverArgument argument)
        {
            BaseRemove(argument);
        }
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}
