using IboshEngine.Runtime.Extensions;
using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            if (onGround && obj.CurrentVelocity.y < .01f) stateMachine.ChangeState(obj.IdleState);
            else
            {
                obj.Rb.SetVelocityX(xInput * objData.MoveSpeed);
                if (obj.CanFlip((int)xInput)) obj.Flip();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
