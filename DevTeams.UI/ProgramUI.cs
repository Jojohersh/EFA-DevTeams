
public class ProgramUI
{
    public bool IsRunning { get; set; }
    private readonly DeveloperRepository devRepo = new DeveloperRepository();
    private readonly DevTeamRepository teamsRepo = new DevTeamRepository();
    public readonly string devListHeading = "ID | Employee Name                           |Team| PluralSight\n----------------------------------------------------------------";
    public void Run()
    {
        devRepo.SeedDB();
        teamsRepo.SeedDB();
        IsRunning = true;
        MainMenu();
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
        Console.Clear();

        while (IsRunning)
        {
            // System.Console.Clear();
            DisplayBanner();

            DisplayMainMenuOptions();
            string menuChoice = System.Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    //Manage Devs
                    DeveloperMenu();
                    break;
                case "2":
                    //Manage Teams
                    DevTeamMenu();
                    break;
                case "3":
                    //Manage Pluralsight
                    PluralSightMenu();
                    break;
                case "4":
                    IsRunning = false;
                    break;
                default:
                    System.Console.WriteLine($"\nInvalid selection: {menuChoice}, please choose an appropriate selection below\n\n");
                    break;
            }

        }
    }
    public void DisplayMainMenuOptions()
    {
        System.Console.WriteLine("\nWelcome to Komodo Insurance");
        System.Console.WriteLine("What would you like to do? (enter 1-4)");
        System.Console.WriteLine("1. Manage developers");
        System.Console.WriteLine("2. Manage teams");
        System.Console.WriteLine("3. Manage Pluralsight access");
        System.Console.WriteLine("4. Exit application");
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
    // PLURAL SIGHT MENU SECTION
    public void PluralSightMenu()
    {
        bool IsRunning = true;
        System.Console.Clear();
        DisplayBanner();
        while (IsRunning)
        {
            System.Console.WriteLine("\nPluralsight Management Menu\n");
            System.Console.WriteLine("----------------------------------------------------------------");
            DisplayNeedsPluralSight();
            DisplayHasPluralSight();

            DisplayPluralSightMenuOptions();
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    System.Console.WriteLine("Add Developer Pluralsight access");
                    SetPluralSight(true);
                    break;
                case "2":
                    //remove pluralsight
                    System.Console.WriteLine("Remove Developer Pluralsight access");
                    SetPluralSight(false);
                    break;
                case "3":
                    //exit
                    IsRunning = false;
                    break;
                default:
                    System.Console.WriteLine($"Invalid selection: {menuChoice}, please choose an appropriate selection from below\n\n");
                    break;
            }
        }
        Console.Clear();
    }
    public void DisplayPluralSightMenuOptions()
    {
        System.Console.WriteLine("\nWhat would you like to do?");
        System.Console.WriteLine("1. Give Devs Pluralsight access");
        System.Console.WriteLine("2. Remove Dev Pluralsight access");
        System.Console.WriteLine("3. Return to main menu");
    }
    public void DisplayNeedsPluralSight()
    {
        List<Developer> noPluralSight = devRepo.GetDevelopersByHasPluralSight(false);
        if (noPluralSight.Count > 0)
            System.Console.WriteLine("\nEmployees without Pluralsight access");
        System.Console.WriteLine("----------------------------------------------------------------");
        System.Console.WriteLine(devListHeading);
        foreach (Developer dev in noPluralSight)
        {
            System.Console.WriteLine(dev);
        }
    }
    public void DisplayHasPluralSight()
    {
        List<Developer> hasPluralSight = devRepo.GetDevelopersByHasPluralSight(true);
        if (hasPluralSight.Count > 0)
        {
            System.Console.WriteLine("\nEmployees with PluralSight access");
            System.Console.WriteLine("----------------------------------------------------------------");
            System.Console.WriteLine(devListHeading);
        }
        foreach (Developer dev in hasPluralSight)
        {
            System.Console.WriteLine(dev);
        }
    }
    public void SetPluralSight(bool HasPluralSight)
    {

        System.Console.WriteLine("Please input the comma separated IDs of developers you wish to add Pluralsight access");
        System.Console.WriteLine("(Example input: 4,25,3,9,100\n");

        string userInput = Console.ReadLine();
        List<int> IDs = ParseIDs(userInput);
        foreach (int ID in IDs)
        {
            Developer dev = devRepo.GetDeveloperByID(ID);
            if (dev != null)
            {
                dev.HasPluralSight = HasPluralSight;
                devRepo.UpdateDeveloperByID(ID, dev);
            }
        }
    }
    // DEVELOPER MENU SECTION
    public void DeveloperMenu()
    {
        bool IsRunning = true;
        Console.Clear();
        while (IsRunning)
        {
            System.Console.WriteLine("\nDeveloper management menu");
            System.Console.WriteLine("----------------------------------------------------------------");
            DisplayDeveloperMenuOptions();
            string menuOption = Console.ReadLine();
            switch (menuOption)
            {
                case "1":
                    //view all
                    DisplayAllDevelopers();
                    break;
                case "2":
                    //add
                    AddNewDeveloper();
                    break;
                case "3":
                    //remove
                    RemoveDeveloper();
                    break;
                case "4":
                    //update
                    UpdateDeveloper();
                    break;
                case "5":
                    IsRunning = false;
                    break;
                default:
                    System.Console.WriteLine($"Invalid selection: {menuOption}, please choose an appropriate selection from below");
                    break;
            }
        }
    }
    public void DisplayDeveloperMenuOptions()
    {
        System.Console.WriteLine("\nWhat would you like to do?");
        System.Console.WriteLine("1. View all developers");
        System.Console.WriteLine("2. Add new developer");
        System.Console.WriteLine("3. Remove a developer");
        System.Console.WriteLine("4. Update existing developer name");
        System.Console.WriteLine("5. Return to main menu");
    }
    public void DisplayAllDevelopers()
    {
        List<Developer> allDevs = devRepo.GetAllDevelopers();
        System.Console.WriteLine();
        System.Console.WriteLine(devListHeading);
        foreach (Developer currentDev in allDevs)
        {
            System.Console.WriteLine(currentDev);
        }

    }
    public void AddNewDeveloper()
    {
        System.Console.WriteLine("Please enter new developer's first name");
        string newDevFirstName = Console.ReadLine();
        System.Console.WriteLine("Please enter new developer's last name");
        string newDevLastName = Console.ReadLine();
        System.Console.WriteLine("Does this developer have access to Pluralsight?");
        System.Console.WriteLine("1. Yes");
        System.Console.WriteLine("2. No");
        string pluralsightInput = Console.ReadLine();
        bool HasPluralSight = false;
        switch (pluralsightInput)
        {
            case "1":
                HasPluralSight = true;
                break;
            default:
                HasPluralSight = false;
                break;
        }
        Developer newDev = new Developer(newDevFirstName + " " + newDevLastName, HasPluralSight);
        devRepo.AddDeveloper(newDev);
    }
    public void RemoveDeveloper()
    {
        System.Console.WriteLine("Please enter the ID of the developer you with to remove");
        string devRemove = Console.ReadLine();
        try
        {
            int devRemoveID = int.Parse(devRemove);
            Developer searchResults = devRepo.GetDeveloperByID(devRemoveID);
            DevTeam searchResultTeam = teamsRepo.GetDevTeamByID(searchResults.TeamID);
            searchResultTeam.RemoveMember(devRemoveID);
            devRepo.DeleteDeveloperByID(devRemoveID);
        }
        catch (System.FormatException)
        {
            System.Console.WriteLine("Invalid ID entered.");
        }
    }
    public void UpdateDeveloper()
    {
        System.Console.WriteLine("Please enter ID of user to update");
        try
        {
            int ID = int.Parse(Console.ReadLine());
            Developer dev = devRepo.GetDeveloperByID(ID);
            System.Console.WriteLine("Please enter updated first name:");
            System.Console.WriteLine($"(current first name: {dev.FirstName}");
            dev.FirstName = Console.ReadLine();
            System.Console.WriteLine("Please enter updated last name:");
            dev.LastName = Console.ReadLine();
            devRepo.UpdateDeveloperByID(ID, dev);

        }
        catch (System.FormatException)
        {
            System.Console.WriteLine("Invalid ID entered.");
        }
    }

    // TEAM MENU SECTION
    public void DevTeamMenu()
    {
        bool IsRunning = true;
        while (IsRunning)
        {
            System.Console.WriteLine("\nDevloper Team management menu");
            System.Console.WriteLine("----------------------------------------------------------------");
            DisplayDevTeamMenuOptions();
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    //display all
                    DisplayAllDevTeams();
                    break;
                case "2":
                    //add new team
                    CreateNewTeam();
                    break;
                case "3":
                    //assign devs to team
                    AssignDevsToDevTeam();
                    break;
                case "4":
                    //rename a team
                    RenameTeam();
                    break;
                case "5":
                    //delete a team
                    DeleteTeam();
                    break;
                case "6":
                    //show all developers
                    DisplayAllDevelopers();
                    break;
                case "7":
                    IsRunning = false;
                    break;
                default:
                    System.Console.WriteLine($"Invalid selection: {menuChoice}, please choose one of the selections below");
                    break;
            }
        }
    }
    public void DisplayDevTeamMenuOptions()
    {
        System.Console.WriteLine("\nWhat would you like to do?");
        System.Console.WriteLine("1. View all teams and developers");
        System.Console.WriteLine("2. Add a new team");
        System.Console.WriteLine("3. Assign developers to a team");
        System.Console.WriteLine("4. Rename a team");
        System.Console.WriteLine("5. Delete a team");
        System.Console.WriteLine("6. Display all developers");
        System.Console.WriteLine("7. Go to main menu");
    }
    public void DisplayAllDevTeams()
    {
        List<DevTeam> teams = teamsRepo.GetAllDevTeams();
        foreach (DevTeam team in teams)
        {
            System.Console.WriteLine($"\nTeam ID:{team.ID} - {team.Name}");
            System.Console.WriteLine("----------------------------------------------------------------");
            System.Console.WriteLine(devListHeading);
            foreach (int memberID in team.Members)
            {
                Developer dev = devRepo.GetDeveloperByID(memberID);
                System.Console.WriteLine(dev);
            }

        }
    }
    public void AssignDevsToDevTeam()
    {
        System.Console.WriteLine("Please enter destination team ID:");
        try
        {
            int destTeamID = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter employee IDs to add to team");
            string devIDsStr = Console.ReadLine();
            List<int> IDs = ParseIDs(devIDsStr);
            AddDevsToDevTeam(IDs, destTeamID);
        }
        catch (System.FormatException)
        {
            System.Console.WriteLine("Invalid ID entered");
        }
    }
    public void AddDevsToDevTeam(List<int> IDs, int destTeamID)
    {
        foreach (int ID in IDs)
        {
            DevTeam currentTeam = null;

            Developer dev = devRepo.GetDeveloperByID(ID);
            if (dev == null) return;

            //remove dev from previous team
            currentTeam = teamsRepo.GetDevTeamByID(dev.TeamID);

            if (currentTeam != null)
            {
                currentTeam.RemoveMember(ID);
                teamsRepo.UpdateDevTeamByID(currentTeam.ID, currentTeam);
            }

            //add dev to new team
            DevTeam newTeam = teamsRepo.GetDevTeamByID(destTeamID);
            newTeam.AddMember(ID);
            dev.TeamID = destTeamID;
            devRepo.UpdateDeveloperByID(ID, dev);
        }
    }
    public void CreateNewTeam()
    {
        System.Console.WriteLine("Please enter name of new team:");
        string newTeamName = Console.ReadLine();
        DevTeam newTeam = new DevTeam(newTeamName);
        teamsRepo.AddDevTeam(newTeam);
    }
    public void RenameTeam()
    {
        System.Console.WriteLine("Please enter ID of team to rename:");
        try
        {
            int TeamID = int.Parse(Console.ReadLine());
            DevTeam team = teamsRepo.GetDevTeamByID(TeamID);
            System.Console.WriteLine("Please enter selected team's new name:");
            System.Console.WriteLine($"current name: {team.Name}");
            team.Name = Console.ReadLine();
            teamsRepo.UpdateDevTeamByID(TeamID, team);
        }
        catch (System.FormatException)
        {
            System.Console.WriteLine("Invalid Team ID entered");
        }
    }
    public void DeleteTeam()
    {
        System.Console.WriteLine("Enter ID of team to delete");
        try
        {
            int TeamID = int.Parse(Console.ReadLine());
            teamsRepo.DeleteDevTeamByID(TeamID);

        }
        catch (System.FormatException)
        {
            System.Console.WriteLine("Invalid ID entered");
        }
    }
}
