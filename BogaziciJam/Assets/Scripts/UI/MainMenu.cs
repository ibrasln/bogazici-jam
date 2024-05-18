using BrunoMikoski.AnimationSequencer;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bogazici.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private AnimationSequencerController openAnim;
        [SerializeField] private AnimationSequencerController closeAnim;

        public void Open()
        {
            openAnim.Play();
        }

        public void Close()
        {
            closeAnim.Play();
        }

        public void Play()
        {
            SceneManager.LoadScene("MainGameScene");
        }

        public void Quit() => Application.Quit();
    }
}
