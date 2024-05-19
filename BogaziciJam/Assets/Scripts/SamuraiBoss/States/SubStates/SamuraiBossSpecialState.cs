using Bogazici.SamuraiBoss.States;
using StateMachine;
using UnityEngine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBossSpecialState : SamuraiAbilityState
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
            obj.InputHandler.UseLowAttackInput();
        }

        public override void Exit()
        {
            base.Exit();


        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Debug.Log("Special State");

            isAbilityDone = true;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }
    }
}
