using Bogazici.SamuraiBoss.States;
using StateMachine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBossOverHeadAttackState : SamuraiAbilityState
    {
        public SamuraiBossOverHeadAttackState(SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            obj.InputHandler.UseLowAttackInput();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


    }
}
