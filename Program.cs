using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;

namespace Sharp7Exemple
{
    class Program
    {

        static void Main(string[] args)
        {
            // Create and connect the client
            var client = new S7Client();
            int result = client.ConnectTo("192.168.137.31", 0, 2);
            if (result == 0)
            {
                Console.WriteLine("Connected to 192.168.137.31");
            }
            else
            {
                Console.WriteLine(client.ErrorText(result));
            }
            Console.WriteLine("\n---- Read DB 2");

            byte[] db2Buffer = new byte[18];
            result = client.DBRead(2, 0, 18, db2Buffer);
            if (result != 0)
            {
                Console.WriteLine("Error: " + client.ErrorText(result));
            }
            int db2dbw2 = S7.GetIntAt(db2Buffer, 2);
            Console.WriteLine("db2.DBW2: " + db2dbw2);

            double db2ddd4 = S7.GetRealAt(db2Buffer, 4);
            Console.WriteLine("db2.DBD4: " + db2ddd4);

            double db2dbd8 = S7.GetDIntAt(db2Buffer, 8);
            Console.WriteLine("db2.DBD8: " + db2dbd8);

            double db2dbd12 = S7.GetDWordAt(db2Buffer, 12);
            Console.WriteLine("db2.DBD12: " + db2dbd12);

            double db2dbw16 = S7.GetWordAt(db2Buffer, 16);
            Console.WriteLine("db2.DBD16: " + db2dbw16);
            // Disconnect the client
            client.Disconnect();
        }
    }

}