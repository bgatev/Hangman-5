namespace Hangman
{
    /// <summary>
    ///     Template Method Design Pattern. Defines a single person "Hangman" game model.
    /// </summary>
    public abstract class Game
    {
        /// <summary>
        ///     The Template Method
        /// </summary>
        public void Play()
        {
            this.Initialize();
            while (!this.IsWon())
            {
                this.Update();
            }
        }

        protected abstract void Initialize();

        protected abstract void Update();

        protected abstract bool IsWon();
    }
}