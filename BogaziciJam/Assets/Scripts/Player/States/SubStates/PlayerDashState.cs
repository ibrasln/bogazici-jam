using IboshEngine.Runtime.Extensions;
using StateMachine;
using UnityEngine;

namespace Bogazici.Player.States
{
    public class PlayerDashState : PlayerAbilityState
    {
        private Vector2 _lastAfterImagePos;

        public PlayerDashState(Player obj, StateMachine<Player, PlayerData> stateMachine, PlayerData objData, string animBoolName) : base(obj, stateMachine, objData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            obj.InputHandler.UseDashInput();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= startingTime + objData.DashCooldown) isAbilityDone = true;
            else
            {
                obj.Rb.SetVelocityX(objData.DashSpeed * obj.FacingDirection);
                CheckIfShouldPlaceAfterImage();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckIfShouldPlaceAfterImage()
        {
            if (Mathf.Abs(obj.transform.position.x - _lastAfterImagePos.x) >= objData.DistanceBetweenAfterImages)
                PlaceAfterImage();
        }

        private void PlaceAfterImage()
        {
            AfterImage afterImage = obj.AfterImageObjectPool.Pull();
            afterImage.gameObject.SetActive(true);

            _lastAfterImagePos = obj.transform.position;
        }
    }
}
