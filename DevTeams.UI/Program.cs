System.Console.WriteLine("Welcome to Komodo Insurance");

DevTeam team = new DevTeam("Product");
//testing create & read paths
DeveloperRepository devRepo = new DeveloperRepository();
devRepo.SeedDB();

List<Developer> allDevs = devRepo.GetAllDevelopers();
foreach (Developer currentDev in allDevs) {
    System.Console.WriteLine($"{currentDev.ID}: {currentDev.FullName}");
}

//testing update path
Developer testDev = devRepo.GetDeveloperByID(0);
testDev.FirstName = "Henry";
testDev.LastName = "Williams";
devRepo.UpdateDeveloperByID(0,testDev);

allDevs = devRepo.GetAllDevelopers();
foreach (Developer currentDev in allDevs) {
    System.Console.WriteLine($"{currentDev.ID}: {currentDev.FullName}");
}
//testing delete path
bool successfullyDeleted = devRepo.DeleteDeveloperByID(1);
System.Console.WriteLine($"\nSuccessfully deleted dev of ID: 1 : {successfullyDeleted}\n");

allDevs = devRepo.GetAllDevelopers();
foreach (Developer currentDev in allDevs) {
    System.Console.WriteLine($"{currentDev.ID}: {currentDev.FullName}");
}