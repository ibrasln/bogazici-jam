using StateMachine;

namespace Bogazici.Player.States
{
    public class PlayerGroundedState : PlayerState
    {
        public PlayerGroundedState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            if (jumpInput && obj.CurrentVelocity.y < 0.01f) stateMachine.ChangeState(obj.JumpState);
            else if (dashInput) stateMachine.ChangeState(obj.DashState);
            else if (attackInput)
            {
                switch (obj.PlayerType)
                {
                    case PlayerType.CyberBoy:
                        if (obj.gameObject.TryGetComponent(out CyberBoy cyberBoy))
                        {
                            cyberBoy.StateMachine.ChangeState(cyberBoy.AttackState);
                        }
                        break;
                    case PlayerType.Samurai:
                        if (obj.gameObject.TryGetComponent(out Samurai samurai))
                        {
                            samurai.StateMachine.ChangeState(samurai.AttackState);
                        }
                        break;
                }
            }
            else if (changeTimeInput && obj.CanChangeTime)
            {
                stateMachine.ChangeState(obj.ChangeTimeState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
