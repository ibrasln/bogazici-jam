namespace Bogazici.Health
{
    public class Health
    {
        public int CurrentHealth;

        public Health(int maxHealth)
        {
            CurrentHealth = maxHealth;
        }

        public void IncreaseHealth(int amount) => CurrentHealth += amount;
    }
}
