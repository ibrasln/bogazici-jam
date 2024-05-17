using Bogazici.Entity;
using Bogazici.Player;
using StateMachine;

namespace Bogazici
{
    public class PlayerState : EntityState<Player.Player, PlayerData>
    {
        protected float xInput;
        protected float yInput;
        protected bool jumpInput;
        protected bool attackInput;

        public PlayerState(Player.Player obj, StateMachine<Player.Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
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

            xInput = obj.InputHandler.XInput;
            yInput = obj.InputHandler.YInput;
            jumpInput = obj.InputHandler.JumpInput;
            attackInput = obj.InputHandler.AttackInput;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
