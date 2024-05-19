using IboshEngine.Runtime.Extensions;
using StateMachine;
using UnityEngine;

namespace Bogazici.SamuraiBoss.States
{
    public class SamuraiBossIdleState : SamuraiBossGroundedState
    {
        public SamuraiBossIdleState(SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            Debug.Log(GetMoveDirection());

            if (GetPlayerDistance() > objData.AgroDistance)
            {
                if (Time.time >= startingTime + objData.AttackCooldown)
                    stateMachine.ChangeState(obj.MoveState);
            }
            else if (Time.time >= startingTime + objData.AttackCooldown)
            {
                stateMachine.ChangeState(obj.AttackState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }



    }
}
