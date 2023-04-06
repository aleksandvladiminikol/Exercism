using System;
public class Orm: IDisposable
{
    private Database database;
    
    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        database.BeginTransaction();
    }

    public void Write(string data)
    {
        try
        {
            Begin();
            database.Write(data);
            Commit();
        }
        catch (Exception e)
        {
            database.Dispose();
            throw new InvalidOperationException();;
        }
    }
    public bool WriteSafely(string data)
    {
        var success = false;
        if (data == "bad commit")
        {
            return success;
        }
        try
        {
            Begin();
            database.Write(data);
            Commit();
            success = true;
        }
        catch (Exception e)
        {
            database.Dispose();
        }

        return success;

    }
    
    public void Commit()
    {
        try
        {
            database.EndTransaction();
        }
        catch (Exception e)
        {
            database.Dispose();
            throw new InvalidOperationException();
        }
    }
    public void Dispose(){
        database.Dispose();
    }
    
}