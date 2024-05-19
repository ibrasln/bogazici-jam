using StateMachine;

namespace Bogazici.SamuraiBoss.States
{
    public class SamuraiAbilityState : SamuraiBossState
    {
        public SamuraiAbilityState(SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        protected bool isAbilityDone;

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
                stateMachine.ChangeState(obj.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void AnimationFinishTrigger()
        {
            isAbilityDone = true;
        }
    }
}
