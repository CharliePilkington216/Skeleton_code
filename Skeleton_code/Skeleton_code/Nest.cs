using AntSimCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton_code
{
    class Nest : Entity
    {
        protected int FoodLevel, NumberOfQueens;
        protected static int NextNestID = 1;

        public Nest(int StartRow, int StartColumn, int StartFood) : base(StartRow, StartColumn)
        {
            FoodLevel = StartFood;
            NumberOfQueens = 1;
            ID = NextNestID;
            NextNestID++;
        }

        public void ChangeFood(int Change)
        {
            FoodLevel += Change;
            if (FoodLevel < 0)
            {
                FoodLevel = 0;
            }
        }

        public int GetFoodLevel()
        {
            return FoodLevel;
        }

        public override void AdvanceStage(List<Nest> Nests, List<Ant> Ants, List<Pheromone> Pheromones)
        {
            if (Ants == null)
            {
                return;
            }
            int AntsToCull = 0;
            int Count = 0;
            foreach (Ant A in Ants)
            {
                if (A.GetNestRow() == Row && A.GetNestColumn() == Column)
                {
                    if (A.GetTypeOfAnt() == "queen")
                    {
                        Count += 10;
                    }
                    else
                    {
                        Count += 2;
                    }
                }
            }
            ChangeFood(-Count);
            if (FoodLevel == 0 && Ants.Count > 0)
            {
                AntsToCull++;
            }
            if (FoodLevel < Ants.Count)
            {
                AntsToCull++;
            }
            if (FoodLevel < Ants.Count * 5)
            {
                AntsToCull++;
                if (AntsToCull > Ants.Count)
                {
                    AntsToCull = Ants.Count;
                }
                for (int A = 1; A <= AntsToCull; A++)
                {
                    int RPos = Program.RGen.Next(0, Ants.Count);
                    if (Ants[RPos].GetTypeOfAnt() == "queen")
                    {
                        NumberOfQueens--;
                    }
                    Ants.RemoveAt(RPos);
                }
            }
            else
            {
                for (int A = 1; A <= NumberOfQueens; A++)
                {
                    int RNo1 = Program.RGen.Next(0, 100);
                    if (RNo1 < 50)
                    {
                        int RNo2 = Program.RGen.Next(0, 100);
                        if (RNo2 < 2)
                        {
                            Ants.Add(new QueenAnt(Row, Column, Row, Column));
                        }
                        else
                        {
                            Ants.Add(new WorkerAnt(Row, Column, Row, Column));
                        }
                    }
                }
            }
        }
    }
}
