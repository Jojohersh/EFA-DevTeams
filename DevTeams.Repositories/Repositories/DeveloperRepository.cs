
public class DeveloperRepository
{
  private readonly List<Developer> _devsDB = new List<Developer>();
  // used to create new IDs
  private int _indexer;
  // constructor
  public DeveloperRepository()
  {
    _indexer = 0;
  }
  // CRUD Ops
  // create
  public bool AddDeveloper(Developer dev)
  {
    if (dev != null)
    {
      dev.ID = _indexer;
      _devsDB.Add(dev);
      _indexer++;
      return true;
    }
    return false;
  }
  // read
  public Developer GetDeveloperByID(int ID)
  {
    Developer searchResult = _devsDB.FirstOrDefault(dev => dev.ID == ID);
    return searchResult;
  }
  //read all
  public List<Developer> GetAllDevelopers()
  {
    return _devsDB;
  }
  // update
  public Developer UpdateDeveloperByID(int ID, Developer updatedDev)
  {
    Developer oldDev = GetDeveloperByID(ID);
    if (oldDev != null)
    {
      oldDev.ID = updatedDev.ID;
      oldDev.TeamID = updatedDev.TeamID;
      oldDev.FirstName = updatedDev.FirstName;
      oldDev.LastName = updatedDev.LastName;
      oldDev.HasPluralSight = updatedDev.HasPluralSight;
      return oldDev;
    }
    return null;
  }
  // Destroy
  public bool DeleteDeveloperByID(int ID) {
    Developer dev = GetDeveloperByID(ID);
    return _devsDB.Remove(dev);
  }
  // utility methods
  public void SeedDB()
  {
    Developer dev1 = new Developer("Jordan Hershberger");
    Developer dev2 = new Developer("Rachael Sievers");
    Developer dev3 = new Developer("Terry Brown");

    DevTeam team = new DevTeam("Product");
    var added = AddDeveloper(dev1);
    System.Console.WriteLine($"Added {dev1.FullName}:{added}");
    added = AddDeveloper(dev2);
    System.Console.WriteLine($"Added {dev2.FullName}:{added}");
    added = AddDeveloper(dev3);
    System.Console.WriteLine($"Added {dev3.FullName}:{added}");
  }
}
