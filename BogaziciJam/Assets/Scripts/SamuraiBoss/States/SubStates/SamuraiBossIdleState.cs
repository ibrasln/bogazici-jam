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


            if (GetPlayerDistance() > objData.AgroDistance)
            {
                if (Time.time >= startingTime + objData.AttackCooldown)
                    stateMachine.ChangeState(obj.MoveState);
            }
            else if (Time.time >= startingTime + objData.AttackCooldown)
            {
                stateMachine.ChangeState(obj.GetNextState());
            }


            //if (xInput != 0) stateMachine.ChangeState(obj.MoveState);
            //if (midAttackInput) stateMachine.ChangeState(obj.MidAttackState);
            //if (lowAttackInput) stateMachine.ChangeState(obj.LowAttackState);
            //if (overHeadAttackInput) stateMachine.ChangeState(obj.OverHeadAttackState);
            //if (specialInput) stateMachine.ChangeState(obj.SpecialState);


        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }



    }
}
