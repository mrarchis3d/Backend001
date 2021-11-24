using Google.Protobuf;
using Grpc.Net.Client;
using GrpClientAPI;
using System;
using System.Text;

namespace ConsoleAppClient
{
    class Program
    {
        static void Main(string[] args)
        {   
            var url = "https://localhost:5001";
            var channel = GrpcChannel.ForAddress(url);
            var client = new Test.TestClient(channel);
            
            Console.WriteLine("Realizando Insercion");
            for (int i = 0; i < 4; i++)
            {
                var guid = Guid.NewGuid().ToString();
                var model = new TestModel
                {
                    IntTest = i,
                    StrTest = i.ToString() + "STR",
                    BoolTest = false,
                    BoolNullTest = true,
                    ByteArrayTest = ByteString.CopyFrom("e#>&*m16", Encoding.Unicode),
                    GuidTest = guid,
                    IntNullTest = 0,
                };
                client.InsertTest(model);
                Console.WriteLine("Insercion realizda = " + guid);
            }
            Console.WriteLine("Realizando Peticion Get");
            var result = client.GetAllTests(new Google.Protobuf.WellKnownTypes.Empty());
            foreach(TestModel test in result.TestModelList)
            {
                Console.WriteLine($"Objeto: {test.GuidTest} -- creado con Guid: {test.GuidTest}");
            }
            Console.ReadLine();
        }
    }
}
