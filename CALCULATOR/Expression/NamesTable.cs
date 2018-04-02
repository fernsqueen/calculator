using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    class NamesTable
    {
        public readonly List<IExpression> names;

        public void AddName(IExpression name)
        {
            this.names.Add(name);
        }

        public void RemoveName(IExpression name)
        {
            this.names.Remove(name);
        }
    }
}
