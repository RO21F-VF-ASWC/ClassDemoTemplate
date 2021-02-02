using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoTemplate
{
    public class ListADT: AbstractADT
    {
        protected override ICollection<string> CreateCollection()
        {
            return new List<string>();
        }
    }
}
