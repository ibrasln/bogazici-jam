using StateMachine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBossSpecialState : SamuraiBossAttackState
    {
        public SamuraiBossSpecialState(SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            isAbilityDone = true;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }
    }
}
