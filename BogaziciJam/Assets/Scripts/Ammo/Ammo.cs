using IboshEngine.Runtime.Extensions;
using IboshEngine.Runtime.Interfaces;
using UnityEngine;

namespace Bogazici.Ammo
{
    public class Ammo : MonoBehaviour
    {
        private Player.Player _player;
        public AmmoData Data;
        private float _direction;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player.Player>();
        }

        private void OnEnable()
        {
            transform.position = _player.ShootPosition.position;
            _direction = _player.FacingDirection * Data.Speed;
        }

        private void Update()
        {
            transform.TranslateX(_direction * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Data.Damage);
                _player.AmmoObjectPool.Push(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            _player.AmmoObjectPool.Push(gameObject);
        }
    }
}
