namespace HangmanGame
{
    /// <summary>
    /// Template Method Design Pattern
    /// </summary>
    public abstract class Game
    {
        protected abstract void Initialize();

        protected abstract void Update();

        protected abstract bool IsWon();

        /// <summary>
        /// The Template Method
        /// </summary>
        public void Play()
        {
            this.Initialize();
            while (!this.IsWon())
            {
                this.Update();
            }
        }
    }
}