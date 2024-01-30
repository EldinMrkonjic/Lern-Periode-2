using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Willkommen bei Jass Planer");

        char yn = 'n';
        while (yn == 'n')
        {
            try
            {
                Console.Write("Wie viele Teams spielen heute: ");
                int anzahlTeams = Convert.ToInt32(Console.ReadLine());

                string[] teams = new string[anzahlTeams];
                int[] punkte = new int[anzahlTeams];

                for (int i = 0; i < anzahlTeams; i++)
                {
                    Console.Write("Wie heisst das Team Nr " + (i + 1) + " ? : ");
                    teams[i] = Console.ReadLine();
                }

                Console.WriteLine("");

                Plan(teams);

                Console.Write("Wollen sie mit dem Spiel beginnen[y|n] : ");
                yn = Convert.ToChar(Console.ReadLine());

                int[] Punkte = new int[anzahlTeams];

                if (teams.Length % 2 != 0)
                {
                    Array.Resize(ref teams, teams.Length + 1);
                    teams[teams.Length - 1] = "Frei";
                }

                if (teams.Length % 2 != 0)
                {
                    Array.Resize(ref teams, teams.Length + 1);
                    teams[teams.Length - 1] = "Frei";
                }

                int numspiele = teams.Length - 1;

                for (int spiel = 1; spiel <= numspiele; spiel++)
                {
                    Console.WriteLine($" Spiel {spiel}:");

                    for (int i = 0; i < teams.Length / 2; i++)
                    {
                        int team1Index = i;
                        int team2Index = teams.Length - 1 - i;

                        string team1 = teams[team1Index];
                        string team2 = teams[team2Index];

                        if (team1 != "Frei" && team2 != "Frei")
                        {
                            Console.WriteLine($"{team1} vs. {team2}");
                            Console.Write($"Wie viele Punkte hat das Team {team1} :");
                            Punkte[i] = Punkte[i] + Convert.ToInt32(Console.ReadLine());

                            Console.Write($"Wie viele Punkte hat das Team {team2} :");
                            Punkte[i + 1] = Punkte[i + 1] + Convert.ToInt32(Console.ReadLine());
                        }

                    }

                    string temp = teams[1];
                    for (int i = 1; i < teams.Length - 1; i++)
                    {
                        teams[i] = teams[i + 1];
                    }
                    teams[teams.Length - 1] = temp;

                    Console.WriteLine();
                }


                ZeigeRangliste(teams, Punkte);

                Console.WriteLine();

            }

            catch
            {
                Console.WriteLine("Das war leider eine Ungültige eingabe.");
            }
        }

        Console.WriteLine("Vielen Dank fürs Benutzen!");
    }

    static void Plan(string[] teams)
    {
        if (teams.Length % 2 != 0)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = "Frei";
        }

        int numspiele = teams.Length - 1;

        for (int spiel = 1; spiel <= numspiele; spiel++)
        {
            Console.WriteLine($" Spiel {spiel}:");

            for (int i = 0; i < teams.Length / 2; i++)
            {
                int team1Index = i;
                int team2Index = teams.Length - 1 - i;

                string team1 = teams[team1Index];
                string team2 = teams[team2Index];

                if (team1 != "Frei" && team2 != "Frei")
                {
                    Console.WriteLine($"{team1} vs. {team2}");
                }
            }

            string temp = teams[1];
            for (int i = 1; i < teams.Length - 1; i++)
            {
                teams[i] = teams[i + 1];
            }
            teams[teams.Length - 1] = temp;

            Console.WriteLine();
        }
    }

    static void ZeigeRangliste(string[] teams, int[] punkte)
    {
        Console.WriteLine("\nRangliste:");


        Dictionary<string, int> teamPunkteMap = new Dictionary<string, int>();

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i] != "Frei")
            {
                teamPunkteMap.Add(teams[i], punkte[i]);
            }
        }


        var sortierteRangliste = teamPunkteMap.OrderByDescending(pair => pair.Value);


        int rang = 1;
        foreach (var eintrag in sortierteRangliste)
        {
            Console.WriteLine($"{rang}. {eintrag.Key} - {eintrag.Value} Punkte");
            rang++;
        }
    }
}



