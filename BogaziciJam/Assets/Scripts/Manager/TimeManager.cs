using IboshEngine.Runtime.Singleton;
using UnityEngine;

namespace Bogazici.Managers
{
    public class TimeManager : IboshSingleton<TimeManager>
    {
        public void SetTimeScale(float value)
        {
            Time.timeScale = value;
        }
    }
}
