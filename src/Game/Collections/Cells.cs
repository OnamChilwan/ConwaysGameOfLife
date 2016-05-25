namespace Game.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Game.Objects;

    public class Cells : IEnumerable<Cell>
    {
        private readonly List<Cell> cells = new List<Cell>();

        public void Animate() // this could move to another class
        {
            for (int i = this.cells.Count() - 1; i >= 0; i--)
            {
                var cell = this.cells[i];
                var neighbours = this.GetNeighbours(cell);

                if (neighbours.Count() < 2)
                {
                    cell.Die();
                }

                //if (neighbours.Count() == 3)
                //{
                //    //var item = new Cell();
                //    //item.SetPosition(new Position(cell.Position.X, cell.Position.Y + 1)); // find unallocated space
                //    //this.cells.Add(item);
                //}

                if (neighbours.Count() >= 4)
                {
                    cell.Die();
                }

                //if (neighbours.Count() <= 1)
                //{
                //    cell.Die();
                //}
            }
        }

        private List<Cell> Get(params Position[] positions)
        {
            var neighbours = new List<Cell>();

            foreach (var i in positions)
            {
                var neighbour = this.cells.FirstOrDefault(x => x.Position.X == i.X && x.Position.Y == i.Y);

                if (neighbour != null)
                {
                    neighbours.Add(neighbour);
                }
            }

            return neighbours;
        }

        private List<Cell> CheckAcross(Cell cell)
        {
            int b = cell.Position.X - 1;
            int c = cell.Position.X + 1;

            var positions = new[] { new Position(b, cell.Position.Y), new Position(c, cell.Position.Y) };

            return this.Get(positions);
        }

        private List<Cell> CheckUpDown(Cell cell)
        {
            int b = cell.Position.Y - 1;
            int c = cell.Position.Y + 1;

            var positions = new[] { new Position(cell.Position.X, b), new Position(cell.Position.X, c) };

            return this.Get(positions);
        }

        private List<Cell> TopLeft(Cell cell)
        {
            int a = cell.Position.X - 1;
            int b = cell.Position.Y - 1;

            var positions = new[] { new Position(a, b) };

            return this.Get(positions);
        }

        private List<Cell> TopRight(Cell cell)
        {
            int a = cell.Position.X + 1;
            int b = cell.Position.Y - 1;

            var positions = new[] { new Position(a, b) };

            return this.Get(positions);
        }

        private List<Cell> BottomLeft(Cell cell)
        {
            int a = cell.Position.X - 1;
            int b = cell.Position.Y + 1;

            var positions = new[] { new Position(a, b) };

            return this.Get(positions);
        }

        private List<Cell> BottomRight(Cell cell)
        {
            int a = cell.Position.X + 1;
            int b = cell.Position.Y + 1;

            var positions = new[] { new Position(a, b) };

            return this.Get(positions);
        }

        private IEnumerable<Cell> GetNeighbours(Cell cell)
        {
             var neighbours = new List<Cell>();

            neighbours.AddRange(this.CheckAcross(cell));
            neighbours.AddRange(this.CheckUpDown(cell));
            neighbours.AddRange(this.TopLeft(cell));
            neighbours.AddRange(this.TopRight(cell));
            neighbours.AddRange(this.BottomLeft(cell));
            neighbours.AddRange(this.BottomRight(cell));

            return neighbours;
        }

        IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
        {
            return this.cells.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this.cells.GetEnumerator();
        }

        public Cell this[int index] => this.cells[index];

        public void Create(Cell cell)
        {
            this.cells.Add(cell);
        }
    }
}