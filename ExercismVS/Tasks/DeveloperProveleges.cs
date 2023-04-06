namespace DeveloperPriveleges;

public class AuthenticationData
{
    public string Email { get; set; }
    public string EyeColor { get; set; }
    public decimal PhiltrumWidth { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
}

public class AdminData: AuthenticationData
{
    public AdminData()
    {
        Email = "admin@ex.ism";
        EyeColor = "green";
        PhiltrumWidth = (decimal)0.9;
        Name = "Chanakya";
        Address1 = "Mumbai";
        Address2 = "India";
    }
}
public class BertrandData : AuthenticationData
{
    public BertrandData()
    {
        Email = "bert@ex.ism";
        EyeColor = "blue";
        PhiltrumWidth = (decimal)0.8;
        Name = "Bertrand";
        Address1 = "Paris";
        Address2 = "France";
    }
}

public class AndersData : AuthenticationData
{
    public AndersData()
    {
        Email = "anders@ex.ism";
        EyeColor = "brown";
        PhiltrumWidth = (decimal)0.85;
        Name = "Anders";
        Address1 = "Redmond";
        Address2 = "USA";
    }
}

public class Authenticator
{
    public Identity Admin => GetIdentity(new AdminData());

    public IDictionary<string, Identity> Developers
    {
        get
        {
            var bertrandData = new BertrandData();
            var andersData = new AndersData();
            
            return new Dictionary<string, Identity>
            {
                { bertrandData.Name, GetIdentity(bertrandData) },
                { andersData.Name, GetIdentity(andersData) }
            };
        }
    }

    private static Identity GetIdentity(AuthenticationData data) =>
        new Identity() {
            Email = data.Email, 
            FacialFeatures = new FacialFeatures() {EyeColor = data.EyeColor, PhiltrumWidth = data.PhiltrumWidth},
            NameAndAddress = new List<string> {data.Name, data.Address1, data.Address2}
        };
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public string EyeColor { get; set; }
    public decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public string Email { get; set; }
    public FacialFeatures FacialFeatures { get; set; }
    public IList<string> NameAndAddress { get; set; }
}