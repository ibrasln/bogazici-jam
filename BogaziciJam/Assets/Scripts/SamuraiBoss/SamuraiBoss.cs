using Bogazici.Managers;
using Bogazici.SamuraiBoss.States;
using IboshEngine.Runtime.Extensions;
using UnityEngine;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBoss : Entity.Entity<SamuraiBossData>
    {
        #region State Machine
        public StateMachine.StateMachine<SamuraiBoss, SamuraiBossData> StateMachine { get; set; }
        public SamuraiBossIdleState IdleState { get; set; }
        public SamuraiBossMoveState MoveState { get; set; }
        public SamuraiBossAttackState AttackState { get; set; }
        //public SamuraiBossMidAttackState MidAttackState { get; set; }
        //public SamuraiBossOverHeadAttackState OverHeadAttackState { get; set; }
        //public SamuraiBossSpecialState SpecialState { get; set; }
        #endregion

        //[ReadOnly] public int[] NextStateArray;
        //[ReadOnly] public int StateArrayCount;

        protected override void Awake()
        {
            base.Awake();

            FacingDirection = -1;

            StateMachine = new();

            IdleState = new(this, StateMachine, Data, "idle");
            MoveState = new(this, StateMachine, Data, "move");
            AttackState = new(this, StateMachine, Data, "attack");
            //MidAttackState = new(this, StateMachine, Data, "midAttack");
            //OverHeadAttackState = new(this, StateMachine, Data, "overheadAttack");
            //SpecialState = new(this, StateMachine, Data, "special");

            //NextStateArray = new[] { 0, 1 };
            //ShuffleNextStateArray();
        }

        protected override void Start()
        {
            base.Start();


            StateMachine.Initialize(IdleState);
        }

        protected override void FixedUpdate()
        {
            if (GameManager.Instance.IsGamePaused) return;
            {

            }
            base.FixedUpdate();

            StateMachine.CurrentState.PhysicsUpdate();
        }

        protected override void Update()
        {
            if (GameManager.Instance.IsGamePaused) return;
            base.Update();

            StateMachine.CurrentState.LogicUpdate();

            transform.SetScaleX(FacingDirection);
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.DrawWireSphere(transform.position, Data.AgroDistance);
        }

        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        public void AnimationStartMovementTrigger() => StateMachine.CurrentState.AnimationStartMovementTrigger();
        public void AnimationStopMovementTrigger() => StateMachine.CurrentState.AnimationStopMovementTrigger();

        //public SamuraiBossState GetNextState()
        //{
        //    if (StateArrayCount >= NextStateArray.Length) ShuffleNextStateArray();
        //    SamuraiBossState nextState = GetSelectedState(NextStateArray[StateArrayCount]);
        //    StateArrayCount++;
        //    return nextState;
        //}
        //private void ShuffleNextStateArray()
        //{
        //    NextStateArray = NextStateArray.Shuffle();
        //    StateArrayCount = 0;

        //    //if (NextStateArray[0] != 2) return;
        //    //NextStateArray[0] = NextStateArray[1];
        //    //NextStateArray[1] = 2;
        //}

        //private SamuraiBossState GetSelectedState(int stateInt)
        //{
        //    return stateInt switch
        //    {
        //        0 => MidAttackState,
        //        1 => OverHeadAttackState,
        //        //2 => SpecialState,
        //        _ => null,
        //    };
        //}
    }
}
