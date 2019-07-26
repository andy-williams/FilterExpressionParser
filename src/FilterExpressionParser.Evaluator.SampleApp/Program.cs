using System;
using System.Diagnostics;

namespace FilterExpressionParser.Evaluator.SampleApp
{
    class Program
    {
        private static FilterExpressionEvaluator _evaluator;

        static void Main(string[] args)
        {
            _evaluator = new FilterExpressionEvaluator();

            Console.WriteLine("Starting typing your expressions...");

            while (true)
            {
                var exp = Console.ReadLine();
                var sw = Stopwatch.StartNew();
                Console.WriteLine($"{exp} = {_evaluator.Evaluate(exp)}");
                Console.WriteLine($"Took: {sw.Elapsed.TotalMilliseconds} ms");
            }
        }
    }
}
