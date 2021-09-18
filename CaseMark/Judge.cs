using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMark
{
    public class Judge
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Judge()
        {
            name = "no name";
            id = -1;
        }
        public Judge(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
