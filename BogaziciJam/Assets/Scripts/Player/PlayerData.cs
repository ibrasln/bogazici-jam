using Bogazici.Entity;
using UnityEngine;

namespace Bogazici.Player
{
    public class PlayerData : EntityData
    {
        [Space(7)]
        [Header("JUMP PROPERTIES")]
        public float JumpPower;

        [Space(7)]
        [Header("DASH PROPERTIES")]
        public float DashCooldown;
        public float DashSpeed;

        [Space(7)]
        [Header("CHANGE TIME PROPERTIES")]
        public float ChangeTimeUsageCooldown;
        public float ChangeTimeCooldown;

        [Space(7)]
        [Header("AFTER IMAGE PROPERTIES")]
        public float DistanceBetweenAfterImages;
        public GameObject AfterImagePrefab;

        [Space(7)]
        [Header("AMMO PROPERTIES")]
        public GameObject AmmoPrefab;

        [Space(7)]
        [Header("KNOCKBACK PROPERTIES")]
        public float KnockbackTime;
        public Vector2 KnockbackForce;

        [Space(7)]
        [Header("ATTACK PROPERTIES")]
        public float AttackMovementSpeed;
        public int AttackAmount;
        public LayerMask WhatIsEnemy;
        public float MeleeAttackRadius;
        public int MeleeAttackDamage;
    }
}
