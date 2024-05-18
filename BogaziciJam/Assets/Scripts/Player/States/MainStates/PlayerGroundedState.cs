using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerGroundedState : PlayerState
    {
        public PlayerGroundedState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            if (jumpInput && obj.CurrentVelocity.y < 0.01f) stateMachine.ChangeState(obj.JumpState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
