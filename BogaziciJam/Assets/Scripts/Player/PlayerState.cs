using Bogazici.Entity;
using StateMachine;

namespace Bogazici.Player
{
    public class PlayerState : EntityState<Player, PlayerData>
    {
        protected float xInput;
        protected float yInput;
        protected bool jumpInput;
        protected bool attackInput;
        protected bool rollInput;
        protected bool changeTimeInput;

        protected bool onGround;

        public PlayerState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            onGround = obj.OnGround;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            // Inputs
            xInput = obj.InputHandler.XInput;
            yInput = obj.InputHandler.YInput;
            jumpInput = obj.InputHandler.JumpInput;
            attackInput = obj.InputHandler.AttackInput;
            rollInput = obj.InputHandler.RollInput;
            changeTimeInput = obj.InputHandler.ChangeTimeInput;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
