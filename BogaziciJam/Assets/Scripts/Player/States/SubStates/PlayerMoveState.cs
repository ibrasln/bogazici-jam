using IboshEngine.Runtime.Extensions;
using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerMoveState : PlayerGroundedState
    {
        public PlayerMoveState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            if (xInput == 0) stateMachine.ChangeState(obj.IdleState);
            else if (yInput < 0) stateMachine.ChangeState(obj.CrouchState);
            else
            {
                obj.Rb.SetVelocityX(xInput * objData.MoveSpeed);
                if (obj.CanFlip(xInput)) obj.Flip();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
