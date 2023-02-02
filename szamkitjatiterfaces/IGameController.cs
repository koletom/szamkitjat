namespace szamkitjatiterfaces
{
    public interface IGameController
    {
        void Kezdes();

        void Ending();

        IGameController Add(IGame game);
    }
}