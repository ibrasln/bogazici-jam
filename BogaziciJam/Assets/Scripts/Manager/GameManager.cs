using IboshEngine.Runtime.Singleton;
using System;
using UnityEngine;

namespace Bogazici.Managers
{
    public class GameManager : IboshSingleton<GameManager>
    {
        public GameTime GameTime;
        public Action OnGameTimeChanged;

        public Player.Player Player;

        protected override void Awake()
        {
            base.Awake();

            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player.Player>();
        }

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
