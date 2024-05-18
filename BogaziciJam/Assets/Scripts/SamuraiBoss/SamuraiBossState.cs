using Bogazici.Entity;
using StateMachine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBossState : EntityState<SamuraiBoss, SamuraiBossData>
    {
        protected float xInput;
        //protected float yInput;
        //protected bool jumpInput;
        protected bool midAttackInput;
        protected bool lowAttackInput;
        protected bool overHeadAttackInput;
        protected bool specialInput;

        public SamuraiBossState(SamuraiBoss obj, StateMachine<SamuraiBoss, SamuraiBossData> stateMachine, SamuraiBossData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
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

            xInput = obj.InputHandler.XInput;
            //yInput = obj.InputHandler.YInput;
            //jumpInput = obj.InputHandler.JumpInput;
            midAttackInput = obj.InputHandler.MidAttackInput;
            lowAttackInput = obj.InputHandler.LowAttackInput;
            overHeadAttackInput = obj.InputHandler.OverHeadAttackInput;
            specialInput = obj.InputHandler.SpecialInput;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
