using IboshEngine.Runtime.Singleton;
using System;

namespace Bogazici.Managers
{
    public class GameManager : IboshSingleton<GameManager>
    {
        public GameTime GameTime;
        public Action OnGameTimeChanged;

        public Player.Player CurrentPlayer;
        public Player.CyberBoy CyberBoy;
        public Player.Samurai Samurai;

        public bool IsGamePaused;

        protected override void Awake()
        {
            base.Awake();
        }

        public void ChangeTime()
        {
            switch (GameTime)
            {
                case GameTime.Cyberpunk:
                    GameTime = GameTime.Japanese;
                    CurrentPlayer = CyberBoy;
                    break;
                case GameTime.Japanese:
                    GameTime = GameTime.Cyberpunk;
                    CurrentPlayer = Samurai;
                    break;
            }

            OnGameTimeChanged?.Invoke();
        }

        public void SetPauseState(bool state)
        {
            IsGamePaused = state;
        }
    }

    public enum GameTime
    {
        Cyberpunk,
        Japanese
    }
}
