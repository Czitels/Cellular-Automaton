using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class Cell
    {
        public int ID;
        public int Qi;
        public int oldState;
        public int newState;
        public double density;
        public bool isRecrystallized;
        public bool isBorder;
        public Cell()
        {
            ID = 0;
            Qi = 0;
            oldState = 0;
            newState = 0;
        }
    }
}
