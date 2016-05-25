namespace Game.Objects
{
    using Game.Collections;

    public class Generation
    {
        public Generation()
        {
            this.Cells = new Cells();
        }

        public Generation(Cells cells)
        {
            this.Cells = cells;
        }

        public void Animate()
        {
            this.Cells.Animate();
        }

        public Cells Cells { get; }
    }
}