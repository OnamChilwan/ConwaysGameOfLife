namespace Game.Objects
{
    using System.Linq;

    using Game.Collections;

    public class World
    {
        private readonly Generations generations = new Generations();

        public World(Cells cells)
        {
            this.generations.CreateGeneration(cells);
        }

        public void NextGeneration()
        {
            this.GetCurrentGeneration().Animate();
        }

        public Cells GetPopulation()
        {
            return this.GetCurrentGeneration().Cells;
        }

        private Generation GetCurrentGeneration()
        {
            return this.generations.Last();
        }
    }
}