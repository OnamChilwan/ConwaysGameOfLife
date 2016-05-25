namespace Game.Objects
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

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