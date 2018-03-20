using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CALCULATOR.Equation
{
    class QuadraticEquation : IEquation
    {
        /// <summary>
        /// Коэффициенты
        /// </summary>
        public float A { get; private set; }
        public float B { get; private set; }
        public float C { get; private set; }

        public float Discriminant { get; private set; }

        public void DrawGraph()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool TryParse(string expression, out QuadraticEquation result)
        {
            result = new QuadraticEquation();

            /// TODO:
            /// Функция для одинаковых степеней(метод для приведения?)
            /// Сделать команду
            /// Дорабоотать при коэфф В и/или с = 0
            /// Где-то сделать приведение выражения к адекватному виду, но мб не здесь и не сейчас
            /// 
            /// пока предполагается, что выражение имеет вид Ax^2+Bx+C=0 сразу и все коэффициенты не 0

            /// Если x^2 первый, то коэфф у него 1
            if (expression.IndexOf("x^2") == 0)
            {
                result.A = 1;
                string[] splitArray = expression.Split(new char[] { 'x' }); /// разделится как A | ^2(+-)B | (+-)C=0
                string splitArrayB;
                if (splitArray[1][2] == '+') /// Если коэфф с плюсом, то плюс удаляем тоже
                {
                    splitArrayB = splitArray[1].Remove(0, 3); /// Чистим символы ^2+, чтобы осталось В
                }
                else splitArrayB = splitArray[1].Remove(0, 2); /// Чистим символы ^2, чтобы осталось -В
                float res;
                if (!float.TryParse(splitArrayB, out res))
                {
                    return false;
                }
                else result.B = res;
                string splitArrayС;
                if (splitArray[2][0] == '+') /// Если коэфф с плюсом, то плюс удаляем тоже
                {
                    splitArrayС = splitArray[2].Remove(0, 1); /// Чистим символ +, чтобы осталось С=0
                    splitArrayС = splitArray[2].Remove(splitArray[2].Length - 2, 2); /// (здесь кстати вылететь может, нужно закрыть) 
                                                                                     /// 
                }
                else splitArrayС = splitArray[2].Remove(splitArray[2].Length - 2, 2); /// Чистим символы =0, чтобы осталось -С
                if (!float.TryParse(splitArrayС, out res))
                {
                    return false;
                }
                else result.C = res;
                result.Discriminant = GetDiscriminant(result.A, result.B, result.C);
                return true;
            }
            /// при коэфф-те -1
            else if (expression.IndexOf("-x^2") == 0)
            {
                result.A = -1;
                string[] splitArray = expression.Split(new char[] { 'x' }); /// разделится как A | ^2(+-)B | (+-)C=0
                string splitArrayB;
                if (splitArray[1][2] == '+') /// Если коэфф с плюсом, то плюс удаляем тоже
                {
                    splitArrayB = splitArray[1].Remove(0, 3); /// Чистим символы ^2+, чтобы осталось В
                }
                else splitArrayB = splitArray[1].Remove(0, 2); /// Чистим символы ^2, чтобы осталось -В
                float res;
                if (!float.TryParse(splitArrayB, out res))
                {
                    return false;
                }
                else result.B = res;
                string splitArrayС;
                if (splitArray[2][0] == '+') /// Если коэфф с плюсом, то плюс удаляем тоже
                {
                    splitArrayС = splitArray[2].Remove(0, 1); /// Чистим символ +, чтобы осталось С=0
                    splitArrayС = splitArray[2].Remove(splitArray[2].Length - 3, 2); /// (здесь кстати вылететь может, нужно закрыть) 
                                                                                     /// 
                }
                else splitArrayС = splitArray[2].Remove(splitArray[2].Length - 3, 2); /// Чистим символы =0, чтобы осталось -С
                if (!float.TryParse(splitArrayС, out res))
                {
                    return false;
                }
                result.Discriminant = GetDiscriminant(result.A, result.B, result.C);
                return true;
            }
            else
            {
                string[] splitArray = expression.Split(new char[] { 'x' }); /// разделится как A | ^2(+-)B | (+-)C=0
                float res;
                if (!float.TryParse(splitArray[0], out res))
                {
                    return false;
                }
                else result.A = res;
                string splitArrayB;
                if (splitArray[1][2] == '+') /// Если коэфф с плюсом, то плюс удаляем тоже
                {
                    splitArrayB = splitArray[1].Remove(0, 3); /// Чистим символы ^2+, чтобы осталось В
                }
                else splitArrayB = splitArray[1].Remove(0, 2); /// Чистим символы ^2, чтобы осталось -В
                if (!float.TryParse(splitArrayB, out res))
                {
                    return false;
                }
                else result.B = res;
                string splitArrayС;
                if (splitArray[2][0] == '+') /// Если коэфф с плюсом, то плюс удаляем тоже
                {
                    splitArrayС = splitArray[2].Remove(0, 1); /// Чистим символ +, чтобы осталось С=0
                    splitArrayС = splitArray[2].Remove(splitArray[2].Length - 3, 2); /// (здесь кстати вылететь может, нужно закрыть) 
                                                                                     /// 
                }
                else splitArrayС = splitArray[2].Remove(splitArray[2].Length - 3, 2); /// Чистим символы =0, чтобы осталось -С
                if (!float.TryParse(splitArrayС, out res))
                {
                    return false;
                }
                result.Discriminant = GetDiscriminant(result.A, result.B, result.C);
                return true;
            }
        }
 

        private static float GetDiscriminant(float a, float b, float c)
        {
            return b * b - (float)4 * a * c;
        }
    }
}
