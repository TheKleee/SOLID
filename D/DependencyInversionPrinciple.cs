//Dependency Inversion Principle:

//Higher level modules should not depend on lover level modules,
//but depend on abstractions.

using System;

public class DependencyInversionPrinciple
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Pseudo Database! :)");
    }
}

//Pseudo Code:
#region Higher level module depends on the lower level one:
//public class MySQLConnection
//{
//    public static string Connect(int userId)
//    {
//        //Handle the database connection...
//        return $"Database Connection{userId}";
//    }
//}

//public class PasswordReminder
//{
//    private MySQLConnection dbConnection;

//    public void Construct(MySQLConnection dbConnection)
//    {
//        this.dbConnection = dbConnection;
//    }
//}
#endregion

//Now PasswordReminder is no longer dependant on MySQLConnection which is a lower level module...
//And iDBConnection is adaptable to all the different databases (reusable code)
#region No longer cares for the database we use (proper code):
public interface iDBConnection
{
    public string Connect(int userId);
}

public class MySQLConnection: iDBConnection
{
    public string Connect(int userId)
    {
        return $"Database Connection{userId}";
    }
}

public class PasswordReminder
{
    private iDBConnection dbConnection;

    public void Construct(iDBConnection dbConnection)
    {
        this.dbConnection = dbConnection;
    }
}
#endregion
