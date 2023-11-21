using System;

namespace BudgetAssistantConsole
{
    class Program
    {
        static double regularIncome = 0;
        static double regularExpenses = 0;
        static double irregularIncome = 0;
        static double irregularExpenses = 0;
        static double budget = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen beim Budget-Assistenten!");

            while (true)
            {
                Console.WriteLine("\n1. Regelmäßige Einnahmen festlegen");
                Console.WriteLine("2. Regelmäßige Ausgaben festlegen");
                Console.WriteLine("3. Außerordentliche Einnahmen festlegen");
                Console.WriteLine("4. Außerordentliche Ausgaben festlegen");
                Console.WriteLine("5. Beenden");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SetRegularIncome();
                        break;
                    case "2":
                        SetRegularExpenses();
                        break;
                    case "3":
                        SetIrregularIncome();
                        break;
                    case "4":
                        SetIrregularExpenses();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Option. Bitte wählen Sie erneut.");
                        break;
                }
            }
        }

        static void SetRegularIncome()
        {
            Console.WriteLine("Geben Sie den Betrag für regelmäßige Einnahmen ein:");
            var input = Console.ReadLine();
            if (ValidateInput(input, out double value))
            {
                regularIncome = value;
                CalculateBudget();
            }
        }

        static void SetRegularExpenses()
        {
            Console.WriteLine("Geben Sie den Betrag für regelmäßige Ausgaben ein:");
            var input = Console.ReadLine();
            if (ValidateInput(input, out double value))
            {
                regularExpenses = value;
                CalculateBudget();
            }
        }

        static void SetIrregularIncome()
        {
            Console.WriteLine("Geben Sie den Betrag für außerordentliche Einnahmen ein:");
            var input = Console.ReadLine();
            if (ValidateInput(input, out double value))
            {
                irregularIncome = value;
                CalculateBudget();
            }
        }

        static void SetIrregularExpenses()
        {
            Console.WriteLine("Geben Sie den Betrag für außerordentliche Ausgaben ein:");
            var input = Console.ReadLine();
            if (ValidateInput(input, out double value))
            {
                irregularExpenses = value;
                CalculateBudget();
            }
        }

        static void CalculateBudget()
        {
            budget = regularIncome - regularExpenses + irregularIncome - irregularExpenses;
            Console.WriteLine($"Ihr aktuelles Budget beträgt: {budget}");
        }

        static bool ValidateInput(string input, out double value)
        {
            if (double.TryParse(input, out value) && value >= 0)
            {
                return true;
            }
            Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine positive Zahl ein.");
            value = 0;
            return false;
        }
    }
}
