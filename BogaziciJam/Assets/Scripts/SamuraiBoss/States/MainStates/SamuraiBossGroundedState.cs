using Bogazici.Managers;
using StateMachine;
using UnityEngine;

namespace Bogazici.SamuraiBoss.States
{
    public class SamuraiBossGroundedState : SamuraiBossState
    {
        public SamuraiBossGroundedState(SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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
            if (GetMoveDirection() > .01f)
            {
                obj.FacingDirection = 1;
            }
            else if (GetMoveDirection() < -.01f)
            {
                obj.FacingDirection = -1;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public float GetPlayerDistance()
        {
            return Vector3.Distance(GameManager.Instance.CurrentPlayer.transform.position, obj.transform.position);
        }
        public float GetMoveDirection()
        {
            return Vector3.Normalize(GameManager.Instance.CurrentPlayer.transform.position - obj.transform.position).x;
        }
    }
}
