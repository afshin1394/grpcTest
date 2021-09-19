using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using AWS.Logger.Core;



namespace serviceTest.Protos
{
    public class MoshtaryDAO
    {



        public MoshtaryList GetMoshtaryByccMasir(MoshtaryRequest moshtaryRequest)

        {
            Debug.WriteLine("start");
            MoshtaryList moshtaryResponse = new MoshtaryList();
            try
            {


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
              //    moshtary.Olaviat = rdr.GetInt32(4);
              //     moshtary.ModateVosol = rdr.GetInt32(5);
            //       moshtary.CodeMoshtary = rdr.GetString(6);
            //       moshtary.Address = rdr.GetString(7);
            //       moshtary.Mobile = rdr.GetString(8);
            //       moshtary.CodeNoeVosolAzMoshtary = rdr.GetInt32(9);
            //       moshtary.CcForoshandeh = rdr.GetInt32(10);
            //       moshtary.CcMasir = rdr.GetInt32(11);
            //       moshtary.ToorVisit = rdr.GetInt32(12);
            //       moshtary.CodeNoeHaml = rdr.GetInt32(13);
            //       moshtary.FNameMoshtary = rdr.GetString(14);
            //       moshtary.LNameMoshtary = rdr.GetString(15);
            //       moshtary.Darajeh = rdr.GetInt32(16);
            //       moshtary.NameDarajeh = rdr.GetString(17);
            //       moshtary.CodeMely = rdr.GetString(18);
            //       moshtary.CodeNoeShakhsiat = rdr.GetInt32(19);
            //       moshtary.CcNoeMoshtary = rdr.GetInt32(20);
            //       moshtary.CcNoeSenf = rdr.GetInt32(21);
            //       moshtary.ShenasehMely = rdr.GetString(22);
            //       moshtary.CodeVazeiat = rdr.GetInt32(23);
            //       moshtary.MasahatMaghazeh = rdr.GetInt32(24);
            //       moshtary.HasAnbar = rdr.GetInt32(25);
            //       moshtary.DateOfMasir = rdr.GetString(33);
            //       moshtary.ControlEtebarForoshandeh = rdr.GetInt32(34);
            //       moshtary.ModateNaghd = rdr.GetInt32(35);
            //       moshtary.TarikhMoarefiMoshtary = rdr.GetString(36);
            //       moshtary.KharejAzMahal = rdr.GetInt32(37);


                    moshtaryResponse.Moshtaries.Add(moshtary);

                    Debug.WriteLine($"{rdr.GetInt32(0)} {rdr.GetInt32(1)} {rdr.GetString(2)} {rdr.GetString(3)} {rdr.GetInt32(4)} {rdr.GetString(14)} {rdr.GetString(36)}");

                }
                con.Close();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }

            return moshtaryResponse;
        }


        public Moshtary insertMoshtary(Moshtary moshtary)
        {
            string cs = @"URI=file:D:\downloads\DataBase.sqlite";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "INSERT INTO Moshtary(ccMoshtary, ccAfrad , NameMoshtary , NameTablo , FNameMoshtary , TarikhMoarefiMoshtary) VALUES('" + moshtary.CcMoshtary + "','" + moshtary.CcAfrad + "','" + moshtary.NameMoshtary + "','" + moshtary.NameTablo + "','" + moshtary.FNameMoshtary + "','" + moshtary.TarikhMoarefiMoshtary + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            return moshtary;
        }
    }
}
