using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoTemplate
{
    public abstract class AbstractADT
    {
        private ICollection<String> _myList;

        public AbstractADT()
        {
            _myList = CreateCollection(); // use the abstract method
        }

        //
        // Template method - to be overrided and will differ from subclass to subclass
        //
        protected abstract ICollection<string> CreateCollection();


        //
        // all the common methods
        //
        public void Add(string item)
        {
            _myList.Add(item);
        }

        public void Clear()
        {
            _myList.Clear();
        }

        public bool Remove(string item)
        {
            return _myList.Remove(item);
        }

        public int Count => _myList.Count;

        public override string ToString()
        {
            string str = "[" + String.Join(",", _myList) + "]";
            return $"{nameof(_myList)}: {str}";
        }
    }
}
