using Bogazici.Player.States;
using IboshEngine.Runtime.Interfaces;
using UnityEngine;

namespace Bogazici.Player
{
    public class Samurai : Player
    {
        public PlayerMeleeAttackState AttackState { get; set; }
        [SerializeField] private Transform meleeAttackPosition;

        protected override void Awake()
        {
            base.Awake();
            AttackState = new(this, StateMachine, Data, "attack");
        }

        public void CreateAttackHitbox()
        {
            Collider2D enemy = Physics2D.OverlapCircle(meleeAttackPosition.position, Data.MeleeAttackRadius, Data.WhatIsEnemy);

            if (enemy.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Data.MeleeAttackDamage);
                Debug.Log("DAMAGED!" + damageable);
            }
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Gizmos.DrawWireSphere(meleeAttackPosition.position, Data.MeleeAttackRadius);
        }
    }
}
