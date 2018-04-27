using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    public class NamesTable
    {
        public readonly List<string> names = new List<string>();
        private List<IExpression> roots = new List<IExpression>();
      
        public bool TryAddName(string name, IExpression root)
        {
            if (NameSearch(name) != null) return false;
            names.Add(name);
            roots.Add(root);
            return true;
        }

        public bool TryRemoveName(string name)
        {
            if (NameSearch(name) == null) return false;
            int indexOfName = names.IndexOf(name);
            names.RemoveAt(indexOfName);
            roots.RemoveAt(indexOfName);
            return true;
        }

        public IExpression NameSearch(string name)
        {
            int indexOfName = names.IndexOf(name);
            if (indexOfName < 0) return null;
            return roots[indexOfName];
        }
    }
}
