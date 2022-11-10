
public class DevTeam
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<int> Members = new List<int>();
    public DevTeam(string teamName)
    {
        Name = teamName;
    }
    public void AddMember(int ID) {
        Members.Add(ID);
    }
    public void RemoveMember(int ID) {
        Members.Remove(ID);
    }
}
