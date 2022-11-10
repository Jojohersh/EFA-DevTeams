
public class DevTeamRepository
{
    private readonly List<DevTeam> _teamsDB = new List<DevTeam>();
    //used to create new IDs
    private int _indexer;
    //constructor
    public DevTeamRepository()
    {
        _indexer = 0;
    }
    //CRUD Ops
    //Create
    public bool AddDevTeam(DevTeam team)
    {
        if (team != null)
        {
            team.ID = _indexer;
            _teamsDB.Add(team);
            _indexer++;
            return true;
        }
        return false;
    }
    //Read
    public DevTeam GetDevTeamByID(int ID)
    {
        DevTeam searchResult = _teamsDB.FirstOrDefault(team => team.ID == ID);
        return searchResult;
    }
    //Read All
    public List<DevTeam> GetAllDevTeams()
    {
        return _teamsDB;
    }
    //Update
    public DevTeam UpdateDevTeamByID(int ID, DevTeam updatedTeam)
    {
        DevTeam oldTeam = GetDevTeamByID(ID);
        if (oldTeam != null)
        {
            oldTeam.ID = updatedTeam.ID;
            oldTeam.Name = updatedTeam.Name;
            oldTeam.Members = updatedTeam.Members;
            return oldTeam;
        }
        return null;
    }
    //Destroy
    public bool DeleteDevTeamByID(int ID)
    {
        DevTeam team = GetDevTeamByID(ID);
        return _teamsDB.Remove(team);
    }
    //utility methods
    public void SeedDB()
    {
        DevTeam team1 = new DevTeam("Product");
        DevTeam team2 = new DevTeam("R&D");
        DevTeam team3 = new DevTeam("DevOps");

        AddDevTeam(team1);
        AddDevTeam(team2);
        AddDevTeam(team3);
    }
}
