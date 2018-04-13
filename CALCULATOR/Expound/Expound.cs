using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expound
{
    class Expound
    {

        public bool IsPartOfAST(string name, IExpression root, ref IExpression parent)
        {
            try
            {
                FuncExpression root1 = (FuncExpression)root;
                foreach (var child in root1.ChildNodes)
                {
                    if (child.GetType() == typeof(NameExpression))
                    {
                        NameExpression variable = (NameExpression)child;
                        if (variable.Name == name)
                        {
                            parent = root1;
                            return true;
                        }
                    }
                    else
                    {
                        IsPartOfAST(name, child, ref parent);
                    }
                }
            }
            catch
            {
            }

            try
            {
                UnaryOperator root1 = (UnaryOperator)root;
                foreach (var child in root1.ChildNodes)
                {
                    if (child.GetType() == typeof(NameExpression))
                    {
                        NameExpression variable = (NameExpression)child;
                        if (variable.Name == name)
                        {
                            parent = root1;
                            return true;
                        }
                    }
                    else
                    {
                        IsPartOfAST(name, child, ref parent);
                    }
                }               
             }
            catch
            {
            }

            try
            {
                BinaryOperator root1 = (BinaryOperator)root;
                foreach (var child in root1.ChildNodes)
                {
                    if (child.GetType() == typeof(NameExpression))
                    {
                        NameExpression variable = (NameExpression)child;
                        if (variable.Name == name)
                        {
                            parent = root1;
                            return true;
                        }
                    }
                    else
                    {
                        IsPartOfAST(name, child, ref parent);
                    }
                }
            }
            catch
            {
            }

            if (parent != null) return true; 
            return false;
        }
    }
}
