using UnityEngine;

namespace Entity
{
    public class Entity<T> : MonoBehaviour where T : EntityData
    {
        #region Components
        public Animator Anim { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        #endregion

        public T Data;
        
        protected virtual void Awake()
        {
            Anim = GetComponent<Animator>();
            Rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update() { }

        protected virtual void FixedUpdate() { }
    }
}