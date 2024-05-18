using IboshEngine.Runtime.Extensions;
using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerJumpState : PlayerAbilityState
    {
        public PlayerJumpState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            obj.Rb.SetVelocityY(objData.JumpPower);
            obj.InputHandler.UseJumpInput();
            isAbilityDone = true;
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
