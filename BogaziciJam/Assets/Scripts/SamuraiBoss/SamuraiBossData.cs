using Bogazici.Entity;
using UnityEngine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBossData : EntityData
    {
        [Space(7)]
        [Header("BOSS SETTINGS")]
        public float AgroDistance;
        public float AttackCooldown;
        public float MovementOutCooldown;


        [Space(7)]
        [Header("ATTACK SETTINGS")]
        public float AttackMovementSpeed;
    }
}
