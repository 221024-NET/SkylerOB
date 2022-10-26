using System;

public class Program
{
	// Fields
	
	// Constructor

	// Methods
	// [access modifier] [modifier] [retu type] [method name] ([parameters])
	public static void Main()
	{
        // Let the games begin
		Program ThCa = new Program();

        
        // handle the exception where it occurs
        ThCa.handledException();
        // nothing to do here

        // Let the exception occur and deal with it here.
        try
        {
           ThCa.unhandledException();
        }
        catch //(IndexOutOfRangeException a)
        {
            //Console.WriteLine("ArrayError triggered-" + a);
            Console.WriteLine("ArrayError triggered-");
        }
        finally
        {
            Console.WriteLine("Message that prints regardless from main.");
        }
        

        // identify the exception where it occurs but send a different one here
        try
        {
            ThCa.findmetheException();
        }
        catch (IndexOutOfRangeException a)
        {
            Console.WriteLine("ArrayError should not have been triggered here-"+a);
        }
        catch (Exception e)
        {
            Console.WriteLine("A message from the error-" + e);
        }
        finally
        {
            Console.WriteLine("Message that prints regardless from main.");
        }
        
        
        Console.WriteLine("End of Program. Exiting.");
        // eop
    }
    
    void handledException()
    {
        int[] sequence = new int[2];
        int digit = sequence.Length;
        Console.WriteLine("Entering handled. Array size is: " + digit);
        Console.WriteLine("There cannot be an element at index " + digit);

        for(int i=0; i<=digit; i++)
        {
            try
            {
                sequence[i] = i;
                Console.WriteLine(i + ": " + sequence[i] + "     Nice");
            }
            catch //(IndexOutOfRangeException a)
            {
                //Console.WriteLine("ArrayError triggered at " + i + ":" + a);
                Console.WriteLine("ArrayError triggered at " + i);
            }
            finally
            {
                Console.WriteLine("Message that prints regardless from handled.");
            }
        }
        Console.WriteLine("Leaving handled");
    }

    void unhandledException()
    {
        int[] sequence = new int[2];
        int digit = sequence.Length;
        Console.WriteLine("Entering unhandled. Array size is: " + digit);
        Console.WriteLine("There cannot be an element at index " + digit);
        for(int i=0; i<=digit; i++)
        {
            sequence[i] = i;
            Console.WriteLine(i + ": " + sequence[i]);
        }
        Console.WriteLine("Leaving unhandled (should never print)");
    }

    void findmetheException()
    {
        int[] sequence = new int[2];
        int digit = sequence.Length;
        Console.WriteLine("Entering find. Array size is: " + digit);
        Console.WriteLine("There cannot be an element at index " + digit);

        for(int i=0; i<=digit; i++)
        {
            try
            {
                sequence[i] = i;
                Console.WriteLine(i + ": " + sequence[i] + "     Nice");
            }
            catch //(IndexOutOfRangeException a)
            {
                //Console.WriteLine("ArrayError triggered at "+i+". "+a+". You deal with it.");
                //throw new ArgumentNullException("Exception in find",a);
                Console.WriteLine("ArrayError triggered at "+i+". You deal with it.");
                throw new ArgumentNullException("Need to replace this with a unique excpetion");
            }
            finally
            {
                Console.WriteLine("Message that prints regardless from find.");
            }
        }
        Console.WriteLine("Leaving find");
    }
}