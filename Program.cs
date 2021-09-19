using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SQLite;

using Grpc.Core;

namespace serviceTest.Protos
{
    class Program
    {
        const int Port = 5003;
        public static void Main(string[] args)
        {
            try
            {
            
                Server server = new Server
                {
                    Services = { MoshtaryService.BindService(new MoshtaryImpl()) },
                    Ports = { new ServerPort("192.168.80.181", Port, ServerCredentials.Insecure) }
                };
                server.Start();

              

                Console.WriteLine("Accounts server listening on port " + Port);
                Console.WriteLine("Press any key to stop " +
                    "the server ...");
                Console.ReadKey();

                MoshtaryList moshtaryResponse = new MoshtaryList();
                string cs = @"URI=file:D:\downloads\DataBase.sqlite";
                using var con = new SQLiteConnection(cs);
                con.Open();

                string stm = "SELECT * FROM Moshtary";

                using var cmd = new SQLiteCommand(stm, con);
                using SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Moshtary moshtary = new Moshtary();
                    moshtary.CcMoshtary = rdr.GetInt32(0);
                    moshtary.CcAfrad = rdr.GetInt32(1);
                    moshtary.NameMoshtary = rdr.GetString(2);
                    moshtary.NameTablo = rdr.GetString(3);
                    moshtary.FNameMoshtary = rdr.GetString(14);
                    moshtary.TarikhMoarefiMoshtary = rdr.GetString(36);
                    moshtaryResponse.Moshtaries.Add(moshtary);
                    Console.WriteLine($"{rdr.GetString(2)} {rdr.GetInt32(1)}");

                }
                con.Close();
                //server.ShutdownAsync().Wait();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Exception encountered: {ex}");
            }
          
        }
    }
}
