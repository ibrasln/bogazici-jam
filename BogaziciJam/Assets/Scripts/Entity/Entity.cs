using IboshEngine.Runtime.Interfaces;
using System;
using UnityEngine;

namespace Bogazici.Entity
{
    public class Entity<T> : MonoBehaviour, IDamageable where T : EntityData
    {
        #region Components
        public Animator Anim { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        #endregion

        #region Collision Checks
        [SerializeField] private Transform groundCheckTransform;
        public bool OnGround
        {
            get => Physics2D.OverlapCircle(groundCheckTransform.position, Data.GroundCheckRadius, Data.WhatIsGround);
        }
        #endregion

        public T Data;
        public Health.Health Health { get; private set; }

        public int FacingDirection { get; set; }

        public Vector2 CurrentVelocity { get; private set; }

        public Action OnDeath;

        protected virtual void Awake()
        {
            Anim = GetComponent<Animator>();
            Rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            FacingDirection = 1;
            Health = new(Data.MaxHealth);
        }

        protected virtual void Update()
        {
            CurrentVelocity = Rb.velocity;
        }

        protected virtual void FixedUpdate() { }

        public virtual bool CanFlip(int xMovement) { return false; }
        public void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0, 180, 0);
        }

        protected virtual void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckTransform.position, Data.GroundCheckRadius);
        }

        public virtual void TakeDamage(int damage)
        {
            Health.CurrentHealth -= damage;

            if (Health.CurrentHealth <= 0) OnDeath?.Invoke();
            //TODO: Add knockback.
        }
    }
}