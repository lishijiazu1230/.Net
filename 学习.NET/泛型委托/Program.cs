using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型委托
{
    class Program
    {
        static void Main(string[] args)
        {
            //**普通方法**
            //Func<int, int, int> funcDemo = new Func<int, int, int>(Test1);
            //**匿名方法**
            //Func<int, int, int> funcDemo = delegate(int a, int b) { return a + b; };
            //**lamber语句**
            //Func<int, int, int> funcDemo = (int a, int b) => { return a + b; };
            //**lamber表达式**
            //Func<int, int, int> funcDemo = (a, b) => a + b;

            //int result = funcDemo(3, 4);
            //Console.WriteLine(result);
            //Console.ReadKey();

            //Action<string> actionDemo = new Action<string>(Test2);
            //actionDemo("这是一个没有返回值的委托");
            //Console.ReadKey();
        }
        static int Test1(int a, int b)
        {
            return a + b;
        }
        static void Test2(string str)
        {
            Console.WriteLine(str);
        }
    }
}
