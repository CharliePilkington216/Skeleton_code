using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton_code
{
    class Pheromone : Entity
    {
        protected int Strength, PheromoneDecay, BelongsTo;

        public Pheromone(int Row, int Column, int BelongsToAnt, int InitialStrength, int Decay)
            : base(Row, Column)
        {
            BelongsTo = BelongsToAnt;
            Strength = InitialStrength;
            PheromoneDecay = Decay;
        }

        public override void AdvanceStage(List<Nest> Nests, List<Ant> Ants, List<Pheromone> Pheromones)
        {
            Strength -= PheromoneDecay;
            if (Strength < 0)
            {
                Strength = 0;
            }
        }

        public void UpdateStrength(int Change)
        {
            Strength += Change;
        }

        public int GetStrength()
        {
            return Strength;
        }

        public int GetBelongsTo()
        {
            return BelongsTo;
        }
    }
}
