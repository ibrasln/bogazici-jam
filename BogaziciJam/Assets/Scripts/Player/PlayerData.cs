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
        [Header("ROLL PROPERTIES")]
        public float RollCooldown;
        public float RollSpeed;

        [Space(7)]
        [Header("CHANGE TIME PROPERTIES")]
        public float ChangeTimeUsageCooldown;
        public float ChangeTimeCooldown;
    }
}
