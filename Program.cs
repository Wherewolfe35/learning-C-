using System;
using Npgsql;

namespace C__spike
{
  class Program
  {
    static void Main(string[] args)
    {
      Random numberGenerator = new Random();
      // Specify connection options and open an connection
      NpgsqlConnection conn = new NpgsqlConnection("Server=192.168.0.18;User Id=wolfea;" +
                              "Password=Marathoner1;Database=c_sharp_spike;");
      conn.Open();

      // Define a query
      NpgsqlCommand cmd = new NpgsqlCommand("select * from todolist", conn);

      // Execute a query
      NpgsqlDataReader dr = cmd.ExecuteReader();

      // Read all rows and output the first column in each row
      while (dr.Read())
        Console.Write("{0}\n", dr[0]);

      // Close connection
      conn.Close();

    Beginning:
      Console.Write("Round this number: ");
      double number = Convert.ToDouble(Console.ReadLine());
      double tax = Math.Ceiling(Math.Round(number * 0.1, 2) * 20) / 20;
      Console.WriteLine("No rounding: " + tax);
      Console.WriteLine("Sales Tax: " + Math.Round(tax, 2));
      double roundedNum = Math.Ceiling(number * 20) / 20;
      double finalNum = number + tax;
      Console.WriteLine("New number: " + finalNum);
      if (rnumber != 0)
      {
        goto Begin;
      };

      double num1;
      double num2;
      double num3;

      Console.Write("Insert a number you would like to divide: ");
      num1 = Convert.ToDouble(Console.ReadLine());
      Console.Write("Please insert the denominator: ");
      num2 = Convert.ToDouble(Console.ReadLine());

    Middle:
      Console.Write("What do you think the answer will be? ");
      num3 = Convert.ToDouble(Console.ReadLine());
      if (num3 == (num1 / num2))
      {
        Console.WriteLine("You were correct!");
      }
      else
      {
        int wrongAnswer = numberGenerator.Next(1, 3);
        switch (wrongAnswer)
        {
          case 1:
            Console.WriteLine("Was that a joke?");
            break;
          case 2:
            Console.WriteLine("You aren't even trying.");
            break;
        }
        goto Middle;
      }

      Console.WriteLine();
      Console.WriteLine("Next Challenge");
      for (int i = 1; i < 20; i++)
      {
        Console.Write(Convert.ToString(i) + " - ");
        if ((i % 2) == 0)
        {
          Console.WriteLine("Even");
        }
        else
        {
          Console.WriteLine("Odd");
        }
      }
    }
  }
}
