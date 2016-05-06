namespace Game.UnitTests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    public class WorldTests
    {
        [TestFixture]
        public class Given_I_Have_An_Empty_World
        {
            private World world;

            [SetUp]
            public void When_Creating_Multiple_Living_Cells()
            {
                var livingCell = new Cell();
                var position = new Position();

                this.world = new World();
                this.world
                    .Generations
                    .CreateGeneration();

                for (int i = 1; i <= 5; i++)
                {
                    //livingCell.SetPosition(position);
                    //position.SetX(5 + i);
                    //position.SetY(5);

                    this.world
                        .GetCurrentGeneration()
                        .Cells
                        .Animate();
                }
            }

            [Test]
            public void Then_A_Generation_Has_Been_Created()
            {
                Assert.That(this.world.Generations.GetNumberOfGenerationsCreated(), Is.EqualTo(1));
            }

            [Test]
            public void Then_The_World_Is_Populated_With_A_Living_Cell()
            {
                Assert.That(this.world.GetCurrentGeneration().Cells.GetPopulation(), Is.EqualTo(5));
            }
        }
    }





    public class World
    {
        public World()
        {
            this.Generations = new Generations();
        }

        public Generations Generations { get; private set; }

        public Generation GetCurrentGeneration()
        {
            return this.Generations.Last();
        }
    }

    public class Generation
    {
        public Generation()
        {
            this.Cells = new Cells();
        }

        public Cells Cells { get; }
    }

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

    public class Cell
    {
        public void SetPosition(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; private set; }
    }

    public class Cells : IEnumerable
    {
        private readonly List<Cell> cells = new List<Cell>();

        public void Animate()
        {
            foreach (var cell in this.cells)
            {
                if (this.HasNeighbour(cell))
                {
                    
                }
            }
        }

        private Cell GetNeighbours()
        {
            //yield return 
        }

        private bool HasNeighbour(Cell cell)
        {
            //4,3
            //X Y
            //5,3
            //5,4
            //5,2
            //4,4
            //4,2
            //3,4
            //3,3
            //3,2
            var result = this.cells.Any(x => 
                (x.Position.X == cell.Position.X - 1) &&
                (x.Position.X == cell.Position.X - 1));

            // 1234567
            //1*******
            //2*******
            //3***C***
            //4*******
            //5*******
            //6*******
            //7*******
        }

        public int GetPopulation()
        {
            return this.cells.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return this.cells.GetEnumerator();
        }
    }

    public class Position
    {
        public void SetX(int x)
        {
            this.X = x;
        }

        public void SetY(int y)
        {
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}