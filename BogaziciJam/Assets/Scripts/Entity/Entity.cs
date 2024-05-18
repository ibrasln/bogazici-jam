using UnityEngine;

namespace Bogazici.Entity
{
    public class Entity<T> : MonoBehaviour where T : EntityData
    {
        #region Components
        public Animator Anim { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        #endregion

        public T Data;

        public int FacingDirection { get; private set; }

        #region Collision Checks
        [SerializeField] private Transform groundCheckTransform;
        public bool OnGround
        {
            get => Physics2D.OverlapCircle(groundCheckTransform.position, Data.GroundCheckRadius, Data.WhatIsGround);
        }
        #endregion

        public Vector2 CurrentVelocity { get; private set; }

        protected virtual void Awake()
        {
            Anim = GetComponent<Animator>();
            Rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            FacingDirection = 1;
        }

        protected virtual void Update()
        {
            CurrentVelocity = Rb.velocity;
        }

        protected virtual void FixedUpdate() { }

        public bool CanFlip(int xInput) { return xInput != 0 && xInput != FacingDirection; }
        public void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0, 180, 0);
        }

        protected virtual void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckTransform.position, Data.GroundCheckRadius);
        }
    }
}