using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton_code
{
    class Cell : Entity
    {
        protected int AmountOfFood;

        public Cell(int StartRow, int StartColumn) : base(StartRow, StartColumn)
        {
            AmountOfFood = 0;
        }

        public int GetAmountOfFood()
        {
            return AmountOfFood;
        }

        public override string GetDetails()
        {
            return $"{base.GetDetails()}{AmountOfFood} food present{Environment.NewLine}{Environment.NewLine}";
        }

        public void UpdateFoodInCell(int Change)
        {
            AmountOfFood += Change;
        }
    }
}
