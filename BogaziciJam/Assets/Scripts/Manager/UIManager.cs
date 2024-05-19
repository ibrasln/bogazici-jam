using BrunoMikoski.AnimationSequencer;
using IboshEngine.Runtime.AudioManagement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bogazici.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI musicVolumeText;
        [SerializeField] private TextMeshProUGUI soundEffectVolumeText;
        private bool _isPanelOpened;
        private bool _canPressESC;

        [SerializeField] private AnimationSequencerController panelOpenAnim;
        [SerializeField] private AnimationSequencerController panelCloseAnim;

        private void Start()
        {
            _canPressESC = true;
            _isPanelOpened = false;
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _canPressESC)
            {
                if (_isPanelOpened)
                {
                    panelCloseAnim.Play();
                }
                else
                {
                    panelOpenAnim.Play();
                }
            }
        }

        public void SetIsPanelOpened(bool state) => _isPanelOpened = state;
        public void SetCanPressESC(bool state) => _canPressESC = state;

        public void SetMusicVolumeText() => musicVolumeText.text = MusicManager.Instance.MusicVolume.ToString();
        public void SetSoundEffectVolumeText() => soundEffectVolumeText.text = SoundEffectManager.Instance.SoundEffectVolume.ToString();
    }
}
