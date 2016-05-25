namespace Game.Objects
{
    public class Cell
    {
        public Cell(Position position)
        {
            this.Position = position;
            this.State = State.Alive;
        }

        public bool IsAlive()
        {
            return this.State == State.Alive;
        }

        public bool IsDead()
        {
            return this.State == State.Deceased;
        }

        public void Die()
        {
            this.State = State.Deceased;
        }

        public Position Position { get; private set; }

        public State State { get; private set; }
    }

    public enum State
    {
        Alive,
        Deceased
    }
}