
public class DevTeam
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int[] Members { get; set; }
    public DevTeam(string teamName)
    {
        Name = teamName;
    }
}
