System.Console.WriteLine("Welcome to Komodo Insurance");

//testing create & read paths
DeveloperRepository devRepo = new DeveloperRepository();
DevTeamRepository teamsRepo = new DevTeamRepository();

devRepo.SeedDB();
teamsRepo.SeedDB();

List<Developer> allDevs = devRepo.GetAllDevelopers();
List<DevTeam> allTeams = teamsRepo.GetAllDevTeams();

foreach (Developer currentDev in allDevs) {
    System.Console.WriteLine($"{currentDev.ID}: {currentDev.FullName}");
}
foreach (DevTeam team in allTeams) {
    System.Console.WriteLine($"{team.ID}: {team.Name}");
}
