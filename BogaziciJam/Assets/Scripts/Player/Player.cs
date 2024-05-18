using Bogazici.Player.States;

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
        public PlayerRollState RollState { get; set; }
        #endregion

        protected override void Awake()
        {
            base.Awake();

            InputHandler = GetComponent<PlayerInputHandler>();
            StateMachine = new();

            IdleState = new(this, StateMachine, Data, "idle");
            MoveState = new(this, StateMachine, Data, "move");
            JumpState = new(this, StateMachine, Data, "jump");
            InAirState = new(this, StateMachine, Data, "inAir");
            CrouchState = new(this, StateMachine, Data, "crouch");
            RollState = new(this, StateMachine, Data, "roll");
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(IdleState);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            StateMachine.CurrentState.PhysicsUpdate();
        }

        protected override void Update()
        {
            base.Update();

            StateMachine.CurrentState.LogicUpdate();
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
        }
    }
}