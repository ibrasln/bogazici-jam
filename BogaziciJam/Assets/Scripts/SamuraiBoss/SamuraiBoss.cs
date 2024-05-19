using Bogazici.SamuraiBoss.States;
using Criaath.Extensions;
using NaughtyAttributes;
using UnityEngine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBoss : Entity.Entity<SamuraiBossData>
    {
        #region Components
        public SamuraiBossInputHandler InputHandler { get; set; }
        #endregion

        #region State Machine
        public StateMachine.StateMachine<SamuraiBoss, SamuraiBossData> StateMachine { get; set; }
        public SamuraiBossIdleState IdleState { get; set; }
        public SamuraiBossMoveState MoveState { get; set; }
        public SamuraiBossMidAttackState MidAttackState { get; set; }
        public SamuraiBossLowAttackState LowAttackState { get; set; }
        public SamuraiBossOverHeadAttackState OverHeadAttackState { get; set; }
        public SamuraiBossSpecialState SpecialState { get; set; }
        #endregion

        [ReadOnly] public int[] NextStateArray;
        [ReadOnly] public int StateArrayCount;

        protected override void Awake()
        {
            base.Awake();

            InputHandler = GetComponent<SamuraiBossInputHandler>();
            StateMachine = new();

            IdleState = new(this, StateMachine, Data, "idle");
            MoveState = new(this, StateMachine, Data, "move");
            MidAttackState = new(this, StateMachine, Data, "midAttack");
            LowAttackState = new(this, StateMachine, Data, "lowAttack");
            OverHeadAttackState = new(this, StateMachine, Data, "overHeadAttack");
            SpecialState = new(this, StateMachine, Data, "special");

            NextStateArray = new[] { 0, 1, 2, 3 };
            ShuffleNextStateArray();
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(IdleState);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            StateMachine.CurrentState.PhysicsUpdate();
        }

        protected override void Update()
        {
            base.Update();

            StateMachine.CurrentState.LogicUpdate();
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.DrawWireSphere(transform.position, Data.AgroDistance);
        }

        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

        public SamuraiBossState GetNextState()
        {
            if (StateArrayCount >= NextStateArray.Length) ShuffleNextStateArray();
            SamuraiBossState nextState = GetSelectedState(NextStateArray[StateArrayCount]);
            StateArrayCount++;
            return nextState;
        }
        private void ShuffleNextStateArray()
        {
            NextStateArray = NextStateArray.Shuffle();
            StateArrayCount = 0;

            if (NextStateArray[0] != 3) return;
            NextStateArray[0] = NextStateArray[1];
            NextStateArray[1] = 3;
        }

        private SamuraiBossState GetSelectedState(int stateInt)
        {
            switch (stateInt)
            {
                case 0: return MidAttackState;
                case 1: return LowAttackState;
                case 2: return OverHeadAttackState;
                case 3: return SpecialState;
                default: return null;
            }
        }
    }
}
