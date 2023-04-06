using System;
using System.Collections.Generic;
public class FacialFeatures: IEqualityComparer<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }
    
    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public bool Equals(FacialFeatures x, FacialFeatures y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.EyeColor == y.EyeColor && x.PhiltrumWidth == y.PhiltrumWidth;
    }

    public int GetHashCode(FacialFeatures obj)
    {
        return HashCode.Combine(obj.EyeColor, obj.PhiltrumWidth);
    }
}

public class Identity: IEqualityComparer<Identity>
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public bool Equals(Identity x, Identity y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Email == y.Email && x.FacialFeatures.Equals(x.FacialFeatures, y.FacialFeatures);
    }

    public int GetHashCode(Identity obj)
    {
        return HashCode.Combine(obj.Email, obj.FacialFeatures);
    }
}

public static class AdminData
{
    public static string Email { get; } = "admin@exerc.ism";
    public static FacialFeatures FacialFeatures { get; } = new FacialFeatures("green", 0.9m);
}

public class Authenticator
{
    private List<Identity> _registeredUsers = new List<Identity>();
    private static readonly Identity AdminIdentity = new Identity(AdminData.Email, AdminData.FacialFeatures);
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceA,faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(identity, AdminIdentity);
    }

    public bool Register(Identity identity)
    {
        if (IsRegistered(identity))
            return false;
        _registeredUsers.Add(identity);
        return true;
    }

    public bool IsRegistered(Identity identity)
    {
        return _registeredUsers.Any(x => x.Equals(x, identity));
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return identityA.GetHashCode() == identityB.GetHashCode();
    }
}
