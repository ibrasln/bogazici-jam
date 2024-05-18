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
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public float GetPlayerDistance()
        {
            return Vector3.Distance(GameManager.Instance.Player.transform.position, obj.transform.position);
        }
        public float GetMoveDirection()
        {
            return Vector3.Normalize(GameManager.Instance.Player.transform.position - obj.transform.position).x;
        }
    }
}
