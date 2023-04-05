using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception();
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        try
        {
            return int.Parse(input);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        try
        {
            result = int.Parse(input);
        }
        catch (Exception e)
        {
            result = 0;
            return false;
        }

        return true;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try
        {
            throw new Exception();
        }
        finally
        {
            disposableObject.Dispose();
        }
    }
}
