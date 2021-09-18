using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMark
{
    public class DBControl
    {
        public static List<Judge> GetJudges()
        {
            List<DbDataRecord> judges = DBParser.GetAllGudge();
            List<Judge> tmpjudge = new List<Judge>();
            foreach (DbDataRecord jd in judges)
                tmpjudge.Add(
                    new Judge(Convert.ToInt32(jd["JudgeID"]),jd["Name"].ToString())
                    );
            return tmpjudge;
        }
        public static int InsertCase(Cases c)
        {
           return DBParser.InsertCase(c.JUDGE.ID, c.CaseNumber, c.CaseName, c.CaseSides, c.CaseDate);
        }
        public static List<Cases> GetAllCases()
        {
            List<Cases> tmpc = new List<Cases>();
            List<DbDataRecord> cases = DBParser.GetAllCases();
            foreach(DbDataRecord d in cases)
            {
                tmpc.Add(
                    new Cases(
                        new Judge(
                            Convert.ToInt32(d["JudgeID"]),d["Name"].ToString()),
                            d["CaseNumber"].ToString(),
                            d["CaseName"].ToString(),
                            d["CaseSides"].ToString(),
                            "",
                            DateTime.Parse(d["CaseDate"].ToString())
                        )
                    );
            }
            return tmpc;
        }
    }
}
