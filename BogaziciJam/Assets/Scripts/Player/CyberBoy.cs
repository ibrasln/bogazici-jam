using Bogazici.Player.States;

namespace Bogazici.Player
{
    public class CyberBoy : Player
    {
        public PlayerRangedAttackState AttackState { get; set; }

        protected override void Awake()
        {
            base.Awake();
            AttackState = new(this, StateMachine, Data, "attack");
        }

        public void Fire()
        {
            Ammo.Ammo ammo = AmmoObjectPool.Pull();
            ammo.gameObject.SetActive(true);
        }
    }
}
