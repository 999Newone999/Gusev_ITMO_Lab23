using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusev_ITMO_Lab23
{
    class Program
    {
        /*Разработать асинхронный метод для вычисления факториала числа. В методе Main выполнить проверку работы метода.*/

        static double MethodFactorial(int n)
        {
            double factorial = 1;
            if (n == 0)
            {
                factorial = 1;
            }
            else
            {
                for (int i = 1; i < n + 1; i++)
                {
                    factorial = factorial * i;
                }
            }
            return factorial;
        }
        static async Task<double> FactorialAsync(int n)
        {
            double result = await Task.Run(() => MethodFactorial(n));
            return result;
        }

        static void Main(string[] args)
        {
            bool inputOk = true;
            int n = 1;
            do
            {
                inputOk = true;
                Console.Write("Число, факториал которого надо найти: ");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    inputOk = false;
                }
            } while (!inputOk);
            double factorial = FactorialAsync(n).Result;
            Console.Write("{0}! = {1}", n, factorial);
            Console.ReadKey();
        }
    }
}
