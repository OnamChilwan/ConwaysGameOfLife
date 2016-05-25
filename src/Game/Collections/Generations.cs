namespace Game.Collections
{
    using System.Collections;
    using System.Collections.Generic;

    using Game.Objects;

    public class Generations : IEnumerable<Generation>
    {
        private List<Generation> generations;

        public Generations()
        {
            this.generations = new List<Generation>();
        }

        public void CreateGeneration()
        {
            this.generations.Add(new Generation());
        }

        public void CreateGeneration(Cells cells)
        {
            this.generations.Add(new Generation(cells));
        }

        public int GetNumberOfGenerationsCreated()
        {
            return this.generations.Count;
        }

        public Generation this[int index] => this.generations[index];

        IEnumerator<Generation> IEnumerable<Generation>.GetEnumerator()
        {
            return this.generations.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this.generations.GetEnumerator();
        }
    }
}