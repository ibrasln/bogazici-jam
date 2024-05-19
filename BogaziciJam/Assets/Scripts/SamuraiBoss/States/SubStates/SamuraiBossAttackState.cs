using Bogazici.SamuraiBoss.States;
using IboshEngine.Runtime.Extensions;
using StateMachine;
using UnityEngine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBossAttackState : SamuraiAbilityState
    {
        private int _attackCounter = Random.Range(1, 3);

        public SamuraiBossAttackState(SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            _attackCounter = Random.Range(1, 3);
            obj.Anim.SetInteger("attackCounter", _attackCounter);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void AnimationFinishTrigger() => isAbilityDone = true;
        public override void AnimationStartMovementTrigger() => obj.Rb.SetVelocityX(objData.AttackMovementSpeed * obj.FacingDirection);
        public override void AnimationStopMovementTrigger() => obj.Rb.SetVelocityZero();
    }
}
