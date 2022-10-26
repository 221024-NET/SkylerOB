using System;

public class Program
{
	// Fields
	
	// Constructor

	// Methods
	// [access modifier] [modifier] [retu type] [method name] ([parameters])
	public static void Main()
	{
        // throw errors in subroutines, catch in main
		Program ThCa = new Program();

        // handle the exception where it occurs
        ThCa.handledException();
        // nothing to do here


        // Let the exception occur and deal with it here.
        try
        {
           ThCa.unhandledException();
        }
        catch (IndexOutOfRangeException a)
        {
            Console.WriteLine("ArrayError triggered-" + a);
        }
        finally
        {
            Console.WriteLine("Message that prints regardless.");
        }
        
        
        Console.WriteLine("End of Program. Exiting.");

    }
    
    void handledException()
    {
        int[] sequence = new int[4];
        int digit = sequence.Length;
        Console.WriteLine("Array size is: " + digit);
        Console.WriteLine("There cannot be an element at index " + digit);

        for(int i=0; i<=digit; i++)
        {
            try
            {
                sequence[i] = i;
                Console.WriteLine(i + ": " + sequence[i] + "     Nice");
            }
            catch (IndexOutOfRangeException a)
            {
                Console.WriteLine("ArrayError triggered at " + i + ":" + a);
            }
            finally
            {
                Console.WriteLine("Message that prints regardless.");
            }
        }
    }

    void unhandledException()
    {
        int[] sequence = new int[5];
        int digit = sequence.Length;
        Console.WriteLine("Array size is: " + digit);
        Console.WriteLine("There cannot be an element at index " + digit);
        for(int i=0; i<=digit; i++)
        {
            sequence[i] = i;
            Console.WriteLine(i + ": " + sequence[i]);
        }
    }
}