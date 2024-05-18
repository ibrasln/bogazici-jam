using IboshEngine.Runtime.Extensions;
using StateMachine;
using UnityEngine;

namespace Bogazici.SamuraiBoss.States
{
    public class SamuraiBossMoveState : SamuraiBossGroundedState
    {
        public SamuraiBossMoveState(SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            if (GetPlayerDistance() <= objData.AgroDistance && Time.time >= startingTime + objData.MovementOutCooldown)
                stateMachine.ChangeState(obj.IdleState);
            else
                obj.Rb.SetVelocityX(GetMoveDirection() * objData.MoveSpeed);

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
