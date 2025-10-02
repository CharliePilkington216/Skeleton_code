using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton_code
{
    class WorkerAnt : Ant
    {
        public WorkerAnt(int StartRow, int StartColumn, int NestInRow, int NestInColumn)
            : base(StartRow, StartColumn, NestInRow, NestInColumn)
        {
            TypeOfAnt = "worker";
            FoodCapacity = 30;
        }

        public override string GetDetails()
        {
            return $"{base.GetDetails()}, carrying {AmountOfFoodCarried} food, home nest is at {NestRow} {NestColumn}";
        }

        public override void ChooseCellToMoveTo(List<int> ListOfNeighbours, int IndexOfNeighbourWithStrongestPheromone)
        {
            if (AmountOfFoodCarried > 0)
            {
                if (Row > NestRow)
                {
                    Row--;
                }
                else if (Row < NestRow)
                {
                    Row++;
                }
                if (Column > NestColumn)
                {
                    Column--;
                }
                else if (Column < NestColumn)
                {
                    Column++;
                }
            }
            else if (IndexOfNeighbourWithStrongestPheromone == -1)
            {
                int IndexToUse = ChooseRandomNeighbour(ListOfNeighbours);
                ChangeCell(IndexToUse, ref Row, ref Column);
            }
            else
            {
                int IndexToUse = ListOfNeighbours.IndexOf(IndexOfNeighbourWithStrongestPheromone);
                ChangeCell(IndexToUse, ref Row, ref Column);
            }
        }
    }
}
