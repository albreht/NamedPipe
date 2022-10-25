using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCFClient
{
    [ServiceContract]
    public interface IStringReverser
    {
        [OperationContract]
        string ReverseString(string value);
    }

    class Program
    {
        static bool lastConnectionBroken=false;
        static ChannelFactory<IStringReverser> pipeFactory =
              new ChannelFactory<IStringReverser>(
                new NetNamedPipeBinding() {
                    OpenTimeout = new TimeSpan(0, 0, 0, 100)
                },
                new EndpointAddress(
                  "net.pipe://localhost/PipeReverse"));

        static IStringReverser pipeProxy =pipeFactory.CreateChannel();
         
        static void Main(string[] args)
        {

            Console.WriteLine($"=================NAMED PIPE TEST CLIENT=============");
            Console.WriteLine($"Press any key to start send");

            Console.ReadLine();
            Console.WriteLine("Sending 1k messages");
            while (true)
            {
            
                // testInteractive();

            
                test100mWithOpenConnection();


                Console.ReadLine();
            }
        }



        public static void test100m() {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //pipeProxy = pipeFactory.CreateChannel();
            for (int i = 0; i < 1000; i++)
            {
                TrySend(i.ToString());
            }
            //pipeFactory.Close();
            
        }

        public static void testInteractive()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            pipeProxy = pipeFactory.CreateChannel();
            while (true) {
                if (Console.Read() == 'q')
                    break;
                pipeProxy.ReverseString("33");
            }
            //pipeFactory.Close();
            Console.WriteLine($"Send in {sw.ElapsedMilliseconds} ms");
        }

        public static void test100mWithOpenConnection() {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            for (int i = 0; i < 1000; i++)
            {
                TrySend("111");
        
            }

            Console.WriteLine($"Send in {sw.ElapsedMilliseconds} ms");
        }



        static void TrySend(string ttt,bool isLastChanceCall=false) {
            try
            {
                pipeProxy.ReverseString(ttt);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
               pipeProxy= pipeFactory.CreateChannel();
                if(!isLastChanceCall)
                    TrySend(ttt,true);
            }
            
        }

 
        ~Program()
        {
            
        }
    }
}