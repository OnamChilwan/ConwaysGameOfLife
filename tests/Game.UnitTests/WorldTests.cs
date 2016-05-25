namespace Game.UnitTests
{
    using System.Linq;

    using Game.Collections;
    using Game.Objects;
    using NUnit.Framework;

    public class WorldTests
    {
        [TestFixture]
        public class Given_I_Have_One_Living_Cell
        {
            private World world;

            [SetUp]
            public void When_Creating_Next_Generation()
            {
                var cells = new Cells();
                cells.Create(new Cell(new Position(2, 2)));

                this.world = new World(cells);
                this.world.NextGeneration();
            }

            [Test]
            public void Then_The_Cell_Dies_Of_Solitude()
            {
                Assert.That(this.world.GetPopulation().Count(), Is.EqualTo(0));
            }
        }

        [TestFixture]
        public class Given_A_Cell_Has_Four_Neighbours
        {
            private World world;

            [SetUp]
            public void When_Creating_Next_Generation()
            {
                var cells = new Cells();
                cells.Create(new Cell(new Position(2, 2)));
                cells.Create(new Cell(new Position(1, 1)));
                cells.Create(new Cell(new Position(2, 1)));
                cells.Create(new Cell(new Position(3, 1)));
                cells.Create(new Cell(new Position(1, 2)));

                this.world = new World(cells);
                this.world.NextGeneration();
            }

            [Test]
            public void Then_The_Cell_Dies_Due_To_Over_Population()
            {
                Assert.That(this.world.GetPopulation().Where(x => x.IsDead()).ToList(), Has.Count.EqualTo(1));
            }
        }

        //[TestFixture]
        //public class Given_A_Cell_Has_Two_Neighbours
        //{
        //    private World world;

        //    [SetUp]
        //    public void When_Creating_Next_Generation()
        //    {
        //        var cells = new Cells();
        //        cells.Create(new Cell());
        //        cells.Create(new Cell());
        //        cells.Create(new Cell());

        //        cells[0].SetPosition(new Position(2, 3));
        //        cells[1].SetPosition(new Position(1, 3));
        //        cells[2].SetPosition(new Position(3, 3));

        //        this.world = new World(cells);
        //        this.world.Animate();
        //    }

        //    [Test]
        //    public void Then_The_Cell_Dies_Due_To_Over_Population()
        //    {
        //        Assert.That(this.world.GetCurrentGeneration().Cells.Count(), Is.EqualTo(4));
        //    }
        //}
    }
}