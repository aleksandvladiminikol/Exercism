namespace Exercism;

using System;

abstract class Character
{
    protected bool vulnerable = false;
    private readonly string _characterType;
    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => vulnerable;

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _preparedSpell = false;
    
    public Wizard() : base("Wizard")
    {
        base.vulnerable = true;
    }

    public override int DamagePoints(Character target)
    {
         return _preparedSpell ? 12 : 3;
    }

    public void PrepareSpell()
    {
        _preparedSpell = true;
        base.vulnerable = false;
    }
}
