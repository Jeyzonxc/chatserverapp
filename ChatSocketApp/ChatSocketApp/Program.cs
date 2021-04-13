﻿using ChatSocketApp.Comunicación;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket serverSocket = new ServerSocket(puerto);
            if(serverSocket.Iniciar())
            {
                //Puedo esperar cliente
                while(true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Esperando Cliente...");
                    if(serverSocket.ObtenerCliente())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Esperando Cliente...")
                        string mensaje = "";

                        while(mensaje.ToLower() != "chao")
                        {
                            string respuesta = serverSocket.Leer();
                            Console.WriteLine("C:{0}", respuesta);
                            if(respuesta.ToLower() != "chao")
                            {
                                Console.WriteLine("Diga lo que quiere decir guruguru");
                                mensaje = Console.ReadLine().Trim();
                                Console.WriteLine("S:{0}", mensaje);
                                serverSocket.Escribir(mensaje);

                            }
                            else
                            {
                                mensaje = "chao";
                            }
                        }
                        serverSocket.CerrarConexion();

                    }
                }

            }else
            {
                //Por permisos no puedo levantar la comunicacion en el puerto
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se puede levantar el servidor, puerto ocupado o sin privilegios");
                Console.ReadKey();
            }
        }
    }
}
