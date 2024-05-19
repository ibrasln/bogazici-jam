using BrunoMikoski.AnimationSequencer;
using IboshEngine.Runtime.Extensions;
using IboshEngine.Runtime.Singleton;
using System;

namespace Bogazici.Managers
{
    public class GameManager : IboshSingleton<GameManager>
    {
        public GameTime GameTime;
        public Action OnGameTimeChanged;

        public Player.Player CurrentPlayer;
        //public Boss CurrentBoss;
        //public CyberpunkBoss CyberpunkBoss;
        public Player.CyberBoy CyberBoy;
        public Player.Samurai Samurai;
        public SamuraiBoss.SamuraiBoss SamuraiBoss;

        public AnimationSequencerController ToCyberpunk;
        public AnimationSequencerController ToSamurai;

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
                    ToSamurai.Play();
                    CurrentPlayer = CyberBoy;
                    //CurrentBoss = CyberpunkBoss;
                    break;
                case GameTime.Japanese:
                    ToCyberpunk.Play();
                    GameTime = GameTime.Cyberpunk;
                    CurrentPlayer = Samurai;
                    //CurrentBoss = SamuraiBoss;
                    break;
            }

            OnGameTimeChanged?.Invoke();
        }

        public void SetPositions()
        {
            switch (CurrentPlayer.PlayerType)
            {
                case Player.PlayerType.CyberBoy:
                    Samurai.transform.SetPosition(CyberBoy.transform.position);
                    break;

                case Player.PlayerType.Samurai:
                    CyberBoy.transform.SetPosition(Samurai.transform.position);
                    break;

                default:
                    break;
            }
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
