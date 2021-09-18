using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMark
{
    public class Cases
    {
        public Judge JUDGE {get;set;}
        public string CaseNumber { get; set; }
        public string CaseName { get; set; }
        public string CaseSides { get; set; }
        public string CaseDesk { get; set; }

        public DateTime CaseDate { get; set; }
       
        public Cases() { }
        public Cases(Judge judge, string casenumber,string casename,string casesides,string casedes,DateTime date)
        {
            CaseNumber = casenumber;
            CaseName = casename;
            CaseSides = casesides;
            CaseDesk = casedes;
            CaseDate = date;
            JUDGE = judge;
        }


    }
}
