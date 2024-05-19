using UnityEngine;

namespace Bogazici.Entity
{
    public class ColliderExtensions : ScriptableObject
    {
        [Header("MOVEMENT")]
        public float MoveSpeed;

        [Space(7)]
        [Header("GROUND CHECK PROPERTIES")]
        public float GroundCheckRadius;
        public LayerMask WhatIsGround;
    }
}