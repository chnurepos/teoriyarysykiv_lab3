using System;

class Program
{
    static double U(double x) => 0.1 * x * x;

    static void Analyze(string name, double a, double b)
    {
        double p = 0.5;
        double expectedValue = (a + b) / 2.0;
        double expectedUtility = p * U(a) + p * U(b);
        double certaintyEquivalent = Math.Sqrt(expectedUtility / 0.1);
        double riskPremium = expectedValue - certaintyEquivalent;

        Console.WriteLine($"Lottery {name}: outcomes {a} and {b}");
        Console.WriteLine($"  Expected value (E[x]) = {expectedValue:F4}");
        Console.WriteLine($"  Expected utility (E[U]) = {expectedUtility:F4}");
        Console.WriteLine($"  Certainty equivalent (CE) = {certaintyEquivalent:F4}");
        Console.WriteLine($"  Risk premium (π = E[x] - CE) = {riskPremium:F4}");

        if (certaintyEquivalent > expectedValue)
            Console.WriteLine("  Risk attitude: risk-seeking");
        else if (certaintyEquivalent < expectedValue)
            Console.WriteLine("  Risk attitude: risk-averse");
        else
            Console.WriteLine("  Risk attitude: risk-neutral");

        Console.WriteLine();
    }

    static void Main()
    {
        Analyze("L1", 0, 20);
        Analyze("L2", 10, 30);

        double eu1 = 0.5 * U(0) + 0.5 * U(20);
        double eu2 = 0.5 * U(10) + 0.5 * U(30);

        Console.WriteLine("Comparison of lotteries by expected utility:");
        Console.WriteLine($"  E[U](L1) = {eu1:F4}, E[U](L2) = {eu2:F4}");

        if (eu1 > eu2)
            Console.WriteLine("  The person prefers Lottery L1.");
        else if (eu2 > eu1)
            Console.WriteLine("  The person prefers Lottery L2.");
        else
            Console.WriteLine("  The person is indifferent between L1 and L2.");
    }
}
