using System.Collections;
using UnityEngine;

namespace Bogazici
{
    public class ShockWaveManager : MonoBehaviour
    {
        [SerializeField] private float _shockWaveTime = 0.75f;
        private Coroutine _shockWaveCoroutine;
        private Material _material;
        private static int _waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");

        private void Awake()
        {
            _material = GetComponent<SpriteRenderer>().material;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                CallShockWave();
            }
        }
        public void CallShockWave()
        {
            _shockWaveCoroutine = StartCoroutine(ShockWaveAction(-0.1f, 1f));
        }

        private IEnumerator ShockWaveAction(float starPos, float endPos)
        {
            _material.SetFloat(_waveDistanceFromCenter, starPos);

            float lerpedAmount = 0f;

            float elapsedTime = 0f;

            while (elapsedTime < _shockWaveTime)
            {
                elapsedTime += Time.deltaTime;

                lerpedAmount = Mathf.Lerp(starPos, endPos, (elapsedTime / _shockWaveTime));
                _material.SetFloat(_waveDistanceFromCenter, lerpedAmount);
                yield return null;
            }
        }
    }
}
