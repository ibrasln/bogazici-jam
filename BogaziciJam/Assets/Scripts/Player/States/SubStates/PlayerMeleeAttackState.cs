using IboshEngine.Runtime.Extensions;
using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerMeleeAttackState : PlayerAbilityState
    {
        private int _attackCounter;

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
            obj.Rb.SetVelocityZero();

            if (_attackCounter > objData.AttackAmount) _attackCounter = 1;
        }

        public override void Exit()
        {
            base.Exit();

            _attackCounter++;
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
