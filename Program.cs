using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;




namespace Snap7Exemple{

    class Program{
        static void Main(string[]args){
            var client = new S7Client();
            int connectionResult = client.ConnectTo("192.168.149.58",0,2);
            if(connectionResult==0){
                Console.WriteLine("Connection ok!");
            }
            else{
                Console.WriteLine("Connection error!");
                return;
            }
            client.Disconnect();
        }
    }
}