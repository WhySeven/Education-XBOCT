using System;
using System.Collections.Generic;

namespace ObjectOrientedProgram {
    class Table {
        int[] tableCellSizes;
        double dego_Square;
        List<double> monte_carlo_Square = new List<double>();
        List<double> relError = new List<double>();
        List<long> ms = new List<long>();
        public Table(MonteCarloCalculator calc) {
            tableCellSizes = new int[] { 14, 24, 30, 26, 12 };
            dego_Square = calc.dego_Square;
            monte_carlo_Square = calc.monte_carlo_Square;
            relError = calc.relError;
            ms = calc.ms;

        }
        public void DrawTable() {
            for (int i = 0; i < 5; i++) {
                DrawHorizontalLine("╔", "╦", "╗", tableCellSizes);
                Console.WriteLine("║ N = {0,-8} ║ dego Square = {1,-8} ║ MonteCarlo Square = {2,-8} ║ Relative Error = {3,-6}% ║ ms = {4,-5} ║", Math.Pow(10, 3 + Convert.ToDouble(i)), Math.Round(dego_Square, 3), Math.Round(monte_carlo_Square[i], 3), Math.Round(relError[i], 3), ms[i]);
                DrawHorizontalLine("╚", "╩", "╝", tableCellSizes);
            }
        }
        private void DrawHorizontalLine(string a, string b, string c, int[] tableCellSizes) {
            Console.Write(a);
            for (int j = 0; j < tableCellSizes.Length; j++) {
                for (int i = 0; i < tableCellSizes[j]; i++) {
                    Console.Write("═");
                }
                if (j != tableCellSizes.Length - 1) {
                    Console.Write(b);
                }
            }
            Console.WriteLine(c);
        }
    }
}
