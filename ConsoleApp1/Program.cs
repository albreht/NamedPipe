using System;
using System.ServiceModel;
using System.Threading;

namespace WCFServer
{
    [ServiceContract]
    public interface IStringReverser
    {
        [OperationContract]
        string ReverseString(string value);
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true, UseSynchronizationContext = false)]
    
    public class StringReverser : IStringReverser
    {
        public StringReverser()
        {
            Console.WriteLine("Client connnected");
        }
        public string ReverseString(string value)
        {
            char[] retVal = value.ToCharArray();
            int idx = 0;
            for (int i = value.Length - 1; i >= 0; i--)
                retVal[idx++] = value[i];
           Console.WriteLine($"{DateTime.Now.ToString()} message received");
            return new string(retVal);
        }
        ~StringReverser()
        {
            Console.WriteLine("Client diconnnected");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"=================NAMED PIPE TEST SERVER=============");
            using (ServiceHost host = new ServiceHost(
              typeof(StringReverser),
              new Uri[]{
 
          new Uri("net.pipe://localhost")
              }))
            {


                host.AddServiceEndpoint(typeof(IStringReverser),
                  new NetNamedPipeBinding()
                  ,
                  "PipeReverse"); ; ;

                host.Open();

        
                Console.WriteLine("Service is available. " +
                  "Press <ENTER> to exit.");
                Console.ReadLine();

                host.Close();
            }
        }

    
    }
}