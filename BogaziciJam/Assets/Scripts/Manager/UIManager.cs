using BrunoMikoski.AnimationSequencer;
using IboshEngine.Runtime.AudioManagement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        [Header("HealthBar Settings")]
        [SerializeField] private Image _bossHealthBar;
        [SerializeField] private Image _playerHealthBar;

        [SerializeField] private Color _cyberpunkColor;
        [SerializeField] private Color _sakuraColor;
        private bool isCyberpunk = true;

        private void Start()
        {
            _canPressESC = true;
            _isPanelOpened = false;
            SetBossHealthValue(0.4f);
            isCyberpunk = false;
            ChangeHealthBarColor();
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

        public void SetBossHealthValue(float value)
        {
            _bossHealthBar.fillAmount = value;
        }
        public void SetPlayerHealthValue(float value)
        {
            _playerHealthBar.fillAmount = value;
        }
        public void ChangeHealthBarColor()
        {
            if (isCyberpunk)
            {
                _bossHealthBar.color = _sakuraColor;
                _playerHealthBar.color = _sakuraColor;
            }
            else
            {
                _bossHealthBar.color = _cyberpunkColor;
                _playerHealthBar.color = _cyberpunkColor;
            }
            isCyberpunk = !isCyberpunk;
        }
    }
}
