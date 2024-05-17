using StateMachine;

namespace Bogazici.Entity
{
    public class EntityState<T1, T2> : State<T1, T2> where T1 : Entity<T2> where T2 : EntityData
    {
        public EntityState(T1 obj, StateMachine<T1, T2> stateMachine, T2 objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            obj.Anim.SetBool(animBoolName, true);
        }

        public override void Exit()
        {
            base.Exit();
            obj.Anim.SetBool(animBoolName, false);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }
    }
}