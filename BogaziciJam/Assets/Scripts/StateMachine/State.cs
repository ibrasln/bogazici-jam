using IboshEngine.Runtime.Interfaces;
using UnityEngine;

namespace StateMachine
{
    public abstract class State<T1, T2> : ILogicUpdate where T1 : MonoBehaviour where T2 : ScriptableObject
    {
        protected T1 obj;
        protected T2 objData;
        protected StateMachine<T1, T2> stateMachine;
        protected float startingTime;
        protected readonly string animBoolName;

        public State(T1 obj, StateMachine<T1, T2> stateMachine, T2 objData, string animBoolName = null)
        {
            this.obj = obj;
            this.stateMachine = stateMachine;
            this.objData = objData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            startingTime = Time.time;
            DoChecks();
        }

        public virtual void Exit()
        {

        }

        public virtual void DoChecks()
        {

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void AnimationFinishTrigger() { }
    }
}
