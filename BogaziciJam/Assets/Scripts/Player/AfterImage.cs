using UnityEngine;

namespace Bogazici.Player
{
    public class AfterImage : MonoBehaviour
    {
        private SpriteRenderer _sr;
        private Transform _player;
        private SpriteRenderer _playerSR;

        private float timeActivated;
        private float alpha;
        [SerializeField] private float activeTime;
        [SerializeField] private float alphaSet;
        [SerializeField] private float alphaDecay;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _playerSR = _player.GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            transform.SetPositionAndRotation(_player.position, _player.rotation);
            timeActivated = Time.time;
            alpha = alphaSet;
            _sr.sprite = _playerSR.sprite;
        }

        private void Update()
        {
            alpha -= alphaDecay * Time.deltaTime;
            _sr.color = new(1, 1, 1, alpha);

            if (Time.time >= timeActivated + activeTime)
            {
                _player.GetComponent<Player>().AfterImageObjectPool.Push(gameObject);
            }
        }
    }
}