using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton_code
{
    class QueenAnt : Ant
    {
        public QueenAnt(int StartRow, int StartColumn, int NestInRow, int NestInColumn)
            : base(StartRow, StartColumn, NestInRow, NestInColumn)
        {
            TypeOfAnt = "queen";
        }
    }
}
