using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerMeleeAttackState : PlayerAbilityState
    {
        public PlayerMeleeAttackState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            obj.InputHandler.UseAttackInput();
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

        public override void AnimationFinishTrigger()
        {
            isAbilityDone = true;
        }
    }
}
