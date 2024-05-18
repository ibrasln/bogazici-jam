using Bogazici.Managers;
using IboshEngine.Runtime.Extensions;
using StateMachine;
using UnityEngine;

namespace Bogazici.Player.States
{
    public class PlayerChangeTimeState : PlayerState
    {
        public PlayerChangeTimeState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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
            GameManager.Instance.ChangeTime();
        }

        public override void Exit()
        {
            base.Exit();

            obj.ResetChangeTimeUsageTimer();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= startingTime + objData.ChangeTimeCooldown) stateMachine.ChangeState(obj.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
