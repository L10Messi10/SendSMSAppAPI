using System;
using System.IO.Ports;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: SendSMS.exe <Port> <GuardianNumber>");
            return;
        }
        string port = args[0];
        string guardianNumber = args[1];
        string guardianName = "John Doe";
        string fullName = "Jane Student";
        string status = DateTime.Now.ToString("tt") == "AM" ? "entered" : "left";
        string message =
            $"Good day {guardianName}, greetings from Carmen National High School. Your son/daughter {fullName} has {status} the school on {DateTime.Now:dddd, dd MMMM yyyy} at {DateTime.Now:hh:mm tt}. This is a system generated message, please don't reply.";

        try
        {
            using (var sp = new SerialPort())
            {
                sp.PortName = port;
                sp.BaudRate = 9600;
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine($"AT+CMGS=\"{guardianNumber}\"" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine(message + Environment.NewLine);
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);
                var response = sp.ReadExisting();
                if (response.Contains("ERROR"))
                {
                    Console.WriteLine("Message was not sent!");
                }
                else
                {
                    Console.WriteLine("Message sent successfully!");
                }
                sp.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
