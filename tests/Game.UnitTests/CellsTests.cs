namespace Game.UnitTests
{
    using System.Linq;

    using Game.Collections;
    using Game.Objects;

    using NUnit.Framework;

    [TestFixture]
    public class CellsTests
    {
        [TestFixture]
        public class Given_A_Cell_Has_Two_Live_Neighbours
        {
            private Cells cells;

            [SetUp]
            public void When_Creating_Next_Generation()
            {
                this.cells = new Cells();
                this.cells.Create(new Cell(new Position(2, 2)));
                this.cells.Create(new Cell(new Position(3, 2)));
                this.cells.Create(new Cell(new Position(1, 1)));
                this.cells.Animate();
            }

            [Test]
            public void Then_The_Cell_Has_Died_Of_Solitude()
            {
                Assert.That(this.cells.First().IsDead(), Is.True);
            }
        }

        [TestFixture]
        public class Given_A_Cell_Has_Three_Live_Neighbours
        {
            private Cells cells;

            [SetUp]
            public void When_Creating_Next_Generation()
            {
                this.cells = new Cells();
                this.cells.Create(new Cell(new Position(2, 2)));
                this.cells.Create(new Cell(new Position(3, 2)));
                this.cells.Create(new Cell(new Position(1, 1)));
                this.cells.Create(new Cell(new Position(3, 1)));
                this.cells.Animate();
            }

            [Test]
            public void Then_The_Cells_Live_On()
            {
                Assert.That(this.cells.Any(x => x.IsDead()), Is.False);
            }
        }

        [TestFixture]
        [Ignore]
        public class Given_A_Cell_Has_Four_Neighbours
        {
            private Cells cells;

            [SetUp]
            public void When_Creating_Next_Generation()
            {
                this.cells = new Cells();
                this.cells.Create(new Cell(new Position(2, 3)));
                this.cells.Create(new Cell(new Position(1, 3)));
                this.cells.Create(new Cell(new Position(3, 3)));
                this.cells.Create(new Cell(new Position(2, 2)));
                this.cells.Create(new Cell(new Position(2, 4)));

                this.cells.Animate();
            }

            [Test]
            public void Then_The_Cell_Dies_Due_To_Over_Population()
            {
                Assert.That(this.cells.Where(x => x.IsDead()).ToList(), Has.Count.EqualTo(1));
            }
        }
    }
}