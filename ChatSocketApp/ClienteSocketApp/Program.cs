using ClienteSocketApp.Comunicación;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Conectado a {0}:{1}", ip, puerto);
            ClienteSocket conServidor = new ClienteSocket(puerto, ip);
            if(conServidor.Conectar())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Conexión establecida");
                string mensaje = "";
                while (mensaje.ToLower() != "chao")
                {
                    Console.WriteLine("Ingrese mensaje");
                    mensaje = Console.ReadLine().Trim();
                    conServidor.Escribir(mensaje);
                    Console.WriteLine("C:{0}", mensaje);
                    if(mensaje.ToLower() != "chao")
                    {
                        mensaje = conServidor.Leer();
                        Console.WriteLine("S:{0}", mensaje);
                    
                    }
              
                }
                Console.WriteLine("Conexión Cerrada");
                Console.ReadKey();
            }
        }
    }
}
