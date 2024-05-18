using IboshEngine.Runtime.Singleton;
using System;

namespace Bogazici.Managers
{
    public class GameManager : IboshSingleton<GameManager>
    {
        public GameTime GameTime;
        public Action OnGameTimeChanged;

        public void ChangeTime()
        {
            switch (GameTime)
            {
                case GameTime.Cyberpunk:
                    GameTime = GameTime.Japanese;
                    break;
                case GameTime.Japanese:
                    GameTime = GameTime.Cyberpunk;
                    break;
            }

            OnGameTimeChanged?.Invoke();
        }
    }

    public enum GameTime
    {
        Cyberpunk,
        Japanese
    }
}
