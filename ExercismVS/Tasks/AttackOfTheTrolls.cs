using System;
using System.Linq;
enum AccountType
{
    [DefaultPermission(Permission.Read)]
    Guest,
    [DefaultPermission(Permission.Read | Permission.Write)]
    User,
    [DefaultPermission(Permission.All)]
    Moderator
}
[Flags]
enum Permission : byte 
{
    Read   = 1,
    Write  = 2,
    Delete = 4,
    All    = 7,
    None   = 0
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
class DefaultPermission : Attribute
{
    public DefaultPermission(Permission permission) => Permission = permission;
    public Permission Permission { get; }
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        var memInfo = accountType.GetType().GetMember(accountType.ToString());
        var attr = (DefaultPermission)memInfo.FirstOrDefault()?.GetCustomAttributes(typeof(DefaultPermission), false)[0];
        return attr?.Permission ?? Permission.None;
    }
    public static Permission Grant(Permission current, Permission grant) => current | grant;
    public static Permission Revoke(Permission current, Permission revoke) => current ^ revoke & current;
    public static bool Check(Permission current, Permission check) => (current & check) == check;

}