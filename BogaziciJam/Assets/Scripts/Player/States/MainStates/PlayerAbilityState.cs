using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        public PlayerAbilityState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            isAbilityDone = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAbilityDone)
            {
                if (onGround && obj.CurrentVelocity.y < 0.01f) stateMachine.ChangeState(obj.IdleState);
                else stateMachine.ChangeState(obj.InAirState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
