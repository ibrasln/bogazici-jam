using Bogazici.SamuraiBoss.States;
using StateMachine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBossMidAttackState : SamuraiAbilityState
    {
        public SamuraiBossMidAttackState
   (SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            obj.InputHandler.UseMidAttackInput();
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