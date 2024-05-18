using IboshEngine.Runtime.Singleton;
using UnityEngine.SceneManagement;

namespace Bogazici.Managers
{
    public class SceneTransitionManager : IboshSingleton<SceneTransitionManager>
    {
        public void ChangeScene(Scene scene)
        {
            SceneManager.LoadScene(scene.buildIndex);
        }
    }
}
