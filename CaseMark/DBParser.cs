using CaseMark.Properties;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaseMark
{
    public class DBParser
    {
        private static string ConnectionString = Settings.Default.CaseMark;

        public static List<DbDataRecord> GetAllGudge()
        {
            List<DbDataRecord> tempData = new List<DbDataRecord>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = "Select * From Judge";

                    SqlDataReader rd = com.ExecuteReader();

                    if (rd.HasRows)
                    {
                        foreach (DbDataRecord d in rd)
                            tempData.Add(d);
                    }
                    else
                        throw new Exception("ბაზები ცარიელია");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return tempData;
        }
        public static int InsertCase(int judgeid,string casenumber,string casename,string casesides,DateTime date )
        {

            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = $@"INSERT INTO Cases (JudgeID,CaseNumber,CaseName,CaseSides,CaseDate) VALUES({judgeid},N'{casenumber}',N'{casename}',N'{casesides}', @date)";
                    com.Parameters.AddWithValue("@date", date);
                    return com.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public static List<DbDataRecord> GetAllCases()
        {
            List<DbDataRecord> tmpr = new List<DbDataRecord>();
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = @"select * from Cases LEFT JOIN Judge ON Cases.JudgeID = Judge.JudgeID where CaseDate >= DATEADD(hour,-1,GETDATE()) Order By CaseDate";

                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord d in dr)
                            tmpr.Add(d);
                    }
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                
                    
            }
            return tmpr;
        }
    }
}
