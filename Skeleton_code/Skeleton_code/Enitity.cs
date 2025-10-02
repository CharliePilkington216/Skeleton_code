using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton_code
{
    class Entity
    {
        protected int Row, Column, ID;

        public Entity(int StartRow, int StartColumn)
        {
            Row = StartRow;
            Column = StartColumn;
        }

        public bool InSameLocation(Entity E)
        {
            return E.GetRow() == Row && E.GetColumn() == Column;
        }

        public int GetRow()
        {
            return Row;
        }

        public int GetColumn()
        {
            return Column;
        }

        public int GetID()
        {
            return ID;
        }

        public virtual void AdvanceStage(List<Nest> Nests, List<Ant> Ants, List<Pheromone> Pheromones)
        {
        }

        public virtual string GetDetails()
        {
            return "";
        }
    }
}
