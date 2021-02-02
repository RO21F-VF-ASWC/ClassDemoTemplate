using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoTemplate
{
    public class SetADT:AbstractADT
    {
        protected override ICollection<string> CreateCollection()
        {
            return new HashSet<String>();
        }
    }
}
