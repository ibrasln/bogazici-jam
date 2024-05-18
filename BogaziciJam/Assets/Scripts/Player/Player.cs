using Bogazici.Managers;
using Bogazici.Player.States;
using IboshEngine.Runtime.ObjectPool;
using UnityEngine;

namespace Bogazici.Player
{
    public class Player : Entity.Entity<PlayerData>
    {
        #region Components
        public PlayerInputHandler InputHandler { get; set; }
        #endregion

        #region State Machine
        public StateMachine.StateMachine<Player, PlayerData> StateMachine { get; set; }
        public PlayerIdleState IdleState { get; set; }
        public PlayerMoveState MoveState { get; set; }
        public PlayerJumpState JumpState { get; set; }
        public PlayerInAirState InAirState { get; set; }
        public PlayerCrouchState CrouchState { get; set; }
        public PlayerDashState DashState { get; set; }
        public PlayerMeleeAttackState MeleeAttackState { get; set; }
        public PlayerRangedAttackState RangedAttackState { get; set; }
        public PlayerChangeTimeState ChangeTimeState { get; set; }
        #endregion

        #region Temporary
        private SpriteRenderer _sr;
        #endregion

        public ObjectPool<AfterImage> AfterImageObjectPool;
        [SerializeField] private Transform afterImagesParent;

        public bool CanChangeTime;
        private float _changeTimeUsageTimer;

        protected override void Awake()
        {
            base.Awake();

            _sr = GetComponent<SpriteRenderer>();

            InputHandler = GetComponent<PlayerInputHandler>();
            StateMachine = new();

            IdleState = new(this, StateMachine, Data, "idle");
            MoveState = new(this, StateMachine, Data, "move");
            JumpState = new(this, StateMachine, Data, "inAir");
            InAirState = new(this, StateMachine, Data, "inAir");
            CrouchState = new(this, StateMachine, Data, "crouch");
            DashState = new(this, StateMachine, Data, "dash");
            MeleeAttackState = new(this, StateMachine, Data, "meleeAttack");
            RangedAttackState = new(this, StateMachine, Data, "rangedAttack");
            ChangeTimeState = new(this, StateMachine, Data, "changeTime");

            AfterImageObjectPool = new(Data.AfterImagePrefab, afterImagesParent, 10);
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(IdleState);
            GameManager.Instance.OnGameTimeChanged += ChangeColor;
        }

        protected override void FixedUpdate()
        {
            if (GameManager.Instance.IsGamePaused) return;
            base.FixedUpdate();

            StateMachine.CurrentState.PhysicsUpdate();
        }

        protected override void Update()
        {
            if (GameManager.Instance.IsGamePaused) return;
            base.Update();

            StateMachine.CurrentState.LogicUpdate();

            if (_changeTimeUsageTimer <= 0f) CanChangeTime = true;
            else _changeTimeUsageTimer -= Time.deltaTime;
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
        }

        public override bool CanFlip(int xInput)
        {
            return xInput != 0 && xInput != FacingDirection;
        }

        private void ChangeColor()
        {
            _sr.color = Color.red;
        }

        public void ResetChangeTimeUsageTimer()
        {
            _changeTimeUsageTimer = Data.ChangeTimeUsageCooldown;
            CanChangeTime = false;
        }

        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    }

}