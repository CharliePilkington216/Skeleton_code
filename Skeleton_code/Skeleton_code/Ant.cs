using AntSimCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton_code
{
    class Ant : Entity
    {
        protected int NestRow, NestColumn, AmountOfFoodCarried, Stages, FoodCapacity;
        protected string TypeOfAnt;
        protected static int NextAntID = 1;

        public Ant(int StartRow, int StartColumn, int NestInRow, int NestInColumn)
            : base(StartRow, StartColumn)
        {
            NestRow = NestInRow;
            NestColumn = NestInColumn;
            ID = NextAntID;
            NextAntID++;
            Stages = 0;
            AmountOfFoodCarried = 0;
            FoodCapacity = 0;
            TypeOfAnt = "";
        }

        public virtual int GetFoodCapacity()
        {
            return FoodCapacity;
        }

        public virtual bool IsAtOwnNest()
        {
            return Row == NestRow && Column == NestColumn;
        }

        public override void AdvanceStage(List<Nest> Nests, List<Ant> Ants, List<Pheromone> Pheromones)
        {
            Stages++;
        }

        public override string GetDetails()
        {
            return $"{base.GetDetails()}  Ant {ID}, {TypeOfAnt}, stages alive: {Stages}";
        }

        public virtual void UpdateFoodCarried(int Change)
        {
            AmountOfFoodCarried += Change;
        }

        protected void ChangeCell(int NewCellIndicator, ref int RowToChange, ref int ColumnToChange)
        {
            if (NewCellIndicator > 5)
            {
                RowToChange++;
            }
            else if (NewCellIndicator < 3)
            {
                RowToChange--;
            }
            if (new int[] { 0, 3, 6 }.Contains(NewCellIndicator))
            {
                ColumnToChange--;
            }
            else if (new int[] { 2, 5, 8 }.Contains(NewCellIndicator))
            {
                ColumnToChange++;
            }
        }

        protected int ChooseRandomNeighbour(List<int> ListOfNeighbours)
        {
            int RNo = 0;
            do
            {
                RNo = Program.RGen.Next(0, ListOfNeighbours.Count);
            } while (ListOfNeighbours[RNo] == -1);
            return RNo;
        }

        public virtual void ChooseCellToMoveTo(List<int> ListOfNeighbours, int IndexOfNeighbourWithStrongestPheromone)
        {
        }

        public virtual int GetFoodCarried()
        {
            return AmountOfFoodCarried;
        }

        public virtual int GetNestRow()
        {
            return NestRow;
        }

        public virtual int GetNestColumn()
        {
            return NestColumn;
        }

        public virtual string GetTypeOfAnt()
        {
            return TypeOfAnt;
        }
    }
}
