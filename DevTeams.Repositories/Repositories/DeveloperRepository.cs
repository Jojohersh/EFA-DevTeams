
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
  //read by Team
  public List<Developer> GetDevelopersByTeamID(int TeamID) {
    List<Developer> results = new List<Developer>();
    foreach (Developer dev in _devsDB) {
      if (dev.TeamID == TeamID) {
        results.Add(dev);
      }
    }
    return results;
  }
  //read by HasPluralSight
  public List<Developer> GetDevelopersByHasPluralSight(bool HasPluralSight) {
    List<Developer> results = new List<Developer>();
    foreach (Developer dev in _devsDB) {
      if (dev.HasPluralSight == HasPluralSight) {
        results.Add(dev);
      }
    }
    return results;
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
    dev1.TeamID = 0;
    Developer dev2 = new Developer("Rachael Sievers", true);
    dev2.TeamID = 2;
    Developer dev3 = new Developer("Terry Brown", true);
    dev3.TeamID = 1;
    Developer dev4 = new Developer("Randy Quaid", true);
    dev4.TeamID = 0;
    Developer dev5 = new Developer("Steve Jobs");
    dev5.TeamID = 2;
    Developer dev6 = new Developer("Ada Lovelace");
    dev6.TeamID = 1;

    AddDeveloper(dev1);
    AddDeveloper(dev2);
    AddDeveloper(dev3);
    AddDeveloper(dev4);
    AddDeveloper(dev5);
    AddDeveloper(dev6);
    
  }
}
