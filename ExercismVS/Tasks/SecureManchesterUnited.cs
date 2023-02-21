using System;

public class SecurityPassMaker
{
    private const string ErrorMessage = "Too Important for a Security Pass";
    public string GetDisplayName(TeamSupport support)
    {
        return support switch
        {
            var i when i.GetType() == typeof(SecurityJunior) => i.Title,
            var i when i.GetType() == typeof(SecurityIntern) => i.Title,
            var i when i.GetType() == typeof(PoliceLiaison) => i.Title,
            var i when i.GetType().IsSubclassOf(typeof(Security)) || i.GetType() == typeof(Security) => string.Join(" ",
                new string[] {i.Title, "Priority Personnel"}),
            var i when i.GetType().IsSubclassOf(typeof(Staff)) => i.Title,
            _ => ErrorMessage
        };
        
    }
}

/**** Please do not alter the code below ****/

public interface TeamSupport { string Title { get; } }

public abstract class Staff : TeamSupport { public abstract string Title { get; } }

public class Manager : TeamSupport { public string Title { get; } = "The Manager"; }

public class Chairman : TeamSupport { public string Title { get; } = "The Chairman"; }

public class Physio : Staff { public override string Title { get; } = "The Physio"; }

public class OffensiveCoach : Staff { public override string Title { get; } = "Offensive Coach"; }

public class GoalKeepingCoach : Staff { public override string Title { get; } = "Goal Keeping Coach"; }

public class Security : Staff { public override string Title { get; } = "Security Team Member"; }

public class SecurityJunior : Security { public override string Title { get; } = "Security Junior"; }

public class SecurityIntern : Security { public override string Title { get; } = "Security Intern"; }

public class PoliceLiaison : Security { public override string Title { get; } = "Police Liaison Officer"; }