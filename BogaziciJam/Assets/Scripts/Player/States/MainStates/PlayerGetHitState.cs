using StateMachine;
using UnityEngine;

namespace Bogazici.Player.States
{
    public class PlayerGetHitState : PlayerState
    {
        public PlayerGetHitState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            //TODO: Shake Camera
            Knockback();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= startingTime + objData.KnockbackTime) stateMachine.ChangeState(obj.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public void Knockback()
        {
            obj.Rb.AddForce(objData.KnockbackForce * obj.KnockbackDirection, ForceMode2D.Impulse);
        }
    }
}
