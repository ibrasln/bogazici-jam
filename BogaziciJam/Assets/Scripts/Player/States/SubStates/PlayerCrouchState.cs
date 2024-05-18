using IboshEngine.Runtime.Extensions;
using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerCrouchState : PlayerGroundedState
    {
        public PlayerCrouchState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            obj.Rb.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (yInput == 0) stateMachine.ChangeState(obj.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
