using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR
{
    /// <summary>
    /// Все типы уравнений - интерфейсы вот этого безобразия
    /// </summary>
    interface IEquation
    {
        /// <summary>
        /// Позже графики для уравнений
        /// </summary>
        void DrawGraph();
        /// <summary>
        /// Попытка проверить правильность выражения(там можно будет внутри применить методы по раскрытию скобок которые потом напишем)
        /// (мб и не нужно парсить именно эти классы а там где-нибудь проверять хз)
        /// </summary>
        ///bool TryParse(string expression, out IEquation result);
    }
}
