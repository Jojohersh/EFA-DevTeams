
public class ProgramUI
{
    public bool IsRunning { get; set; }
    private readonly DeveloperRepository devRepo = new DeveloperRepository();
    private readonly DevTeamRepository teamsRepo = new DevTeamRepository();
    public void Run()
    {
        devRepo.SeedDB();
        teamsRepo.SeedDB();
        IsRunning = true;
        MainMenu();



        // List<Developer> allDevs = devRepo.GetAllDevelopers();
        // List<DevTeam> allTeams = teamsRepo.GetAllDevTeams();

        // foreach (Developer currentDev in allDevs)
        // {
        //     System.Console.WriteLine($"{currentDev.ID}: {currentDev.FullName}");
        // }
        // foreach (DevTeam team in allTeams)
        // {
        //     System.Console.WriteLine($"{team.ID}: {team.Name}");
        // }


        // //test string for parsing multiple IDs
        // string str = "1, 12,3,4 6 a ,5 ";
        // System.Console.WriteLine($"User input: {str}");
        // List<int> parsedIDs = ParseIDs(str);
        // foreach (int parsedID in parsedIDs)
        // {
        //     System.Console.WriteLine(parsedID);
        // }
    }
    public void DisplayBanner()
    {
        System.Console.WriteLine(" /$$   /$$                                         /$$");
        System.Console.WriteLine("| $$  /$$/                                        | $$                                  ");
        System.Console.WriteLine("| $$ /$$/   /$$$$$$  /$$$$$$/$$$$   /$$$$$$   /$$$$$$$  /$$$$$$                         ");
        System.Console.WriteLine("| $$$$$/   /$$__  $$| $$_  $$_  $$ /$$__  $$ /$$__  $$ /$$__  $$                        ");
        System.Console.WriteLine("| $$  $$  | $$  \\ $$| $$ \\ $$ \\ $$| $$  \\ $$| $$  | $$| $$  \\ $$                        ");
        System.Console.WriteLine("| $$\\  $$ | $$  | $$| $$ | $$ | $$| $$  | $$| $$  | $$| $$  | $$                        ");
        System.Console.WriteLine("| $$ \\  $$|  $$$$$$/| $$ | $$ | $$|  $$$$$$/|  $$$$$$$|  $$$$$$/                        ");
        System.Console.WriteLine("|__/  \\__/ \\______/ |__/ |__/ |__/ \\______/  \\_______/ \\______/                         ");
        System.Console.WriteLine(" /$$$$$$                                                                                ");
        System.Console.WriteLine("|_  $$_/                                                                                ");
        System.Console.WriteLine("  | $$   /$$$$$$$   /$$$$$$$ /$$   /$$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$ ");
        System.Console.WriteLine("  | $$  | $$__  $$ /$$_____/| $$  | $$ /$$__  $$ |____  $$| $$__  $$ /$$_____/ /$$__  $$");
        System.Console.WriteLine("  | $$  | $$  \\ $$|  $$$$$$ | $$  | $$| $$  \\__/  /$$$$$$$| $$  \\ $$| $$      | $$$$$$$$");
        System.Console.WriteLine("  | $$  | $$  | $$ \\____  $$| $$  | $$| $$       /$$__  $$| $$  | $$| $$      | $$_____/");
        System.Console.WriteLine(" /$$$$$$| $$  | $$ /$$$$$$$/|  $$$$$$/| $$      |  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$");
        System.Console.WriteLine("|______/|__/  |__/|_______/  \\______/ |__/       \\_______/|__/  |__/ \\_______/ \\_______/");
        System.Console.WriteLine("\n========================================================================================\n");
    }

    public void MainMenu()
    {
        DisplayBanner();
        string menuChoice = "";
        while (IsRunning)
        {
            // System.Console.Clear();

            DisplayMainMenuOptions();
            menuChoice = System.Console.ReadLine();
            switch (menuChoice)
            {
                case "":
                    break;
                case "1":

                    break;
                case "2":
                    break;
                case "3":
                    DisplayNeedsPluralSight();
                    break;
                case "4":
                    break;
                case "5":
                    IsRunning = false;
                    break;
                default:
                    System.Console.WriteLine($"\nInvalid selection: {menuChoice}, please choose an appropriate selection below\n\n");
                    break;
            }

        }
    }
    public List<int> ParseIDs(string str)
    {
        List<int> parsedIDs = new List<int>();

        //split the string by spaces or commas
        char[] separators = { ',', ' ' };
        //don't allow any empty entries
        string[] IDs = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (var ID in IDs)
        {
            try
            {
                int parsedID = int.Parse(ID);
                parsedIDs.Add(parsedID);
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine($"Warning: \"{ID}\" could not be converted to an ID");
            }
        }

        return parsedIDs;
    }
    public void DisplayNeedsPluralSight()
    {
        System.Console.Clear();
        List<Developer> noPluralSight = devRepo.GetDevelopersNotHasPluralSight();
        if (noPluralSight.Count > 0)
            System.Console.WriteLine("\nEmployees without Pluralsight access");
        System.Console.WriteLine("----------------------------------------------------------------");
        System.Console.WriteLine("ID | Employee Name                          |Team| PluralSight");
        System.Console.WriteLine("----------------------------------------------------------------");
        foreach (Developer dev in noPluralSight)
        {
            System.Console.WriteLine(dev);
        }
    }

    public void DisplayMainMenuOptions()
    {
        System.Console.WriteLine("\nWelcome to Komodo Insurance");
        System.Console.WriteLine("What would you like to do? (enter 1-5)");
        System.Console.WriteLine("1. View all developers");
        System.Console.WriteLine("2. View all teams");
        System.Console.WriteLine("3. View developers without Pluralsight access");
        System.Console.WriteLine("4. Manage Teams");
        System.Console.WriteLine("5. Exit application");
    }

}
