namespace szamkitjatiterfaces
{
    public interface IGame
    {
        string Name { get; }

        void Start();

        void Play();

        void End();
    }
}