
public class Developer
{
  //properties
  public int ID { get; set; }
  public int TeamID {get; set;}
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string FullName
  {
    get
    {
      return $"{FirstName} {LastName}";
    }
  }
  public bool HasPluralSight { get; set; }=false;
  // constructors
  public Developer(string fullName)
  {
    string[] splitName = fullName.Split(' ');
    FirstName = splitName[0];
    LastName = splitName[1];
  }
  public Developer(string fullName, bool hasPluralSight)
  {
    string[] splitName = fullName.Split(' ');
    FirstName = splitName[0];
    LastName = splitName[1];
    HasPluralSight = hasPluralSight;
  }
  // methods
  public override string ToString() {
    return ID.ToString().PadRight(3) + "| "+FullName.PadRight(40) + "| " + TeamID.ToString().PadRight(3) + "| " + HasPluralSight.ToString();
  }
}
