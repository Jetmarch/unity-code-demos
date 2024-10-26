using System.Linq;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class GameListenerInstaller : MonoBehaviour
    {
        [Inject]
        private void Construct(GameManager gameManager)
        {
            foreach (var listener in GetComponentsInChildren<IGameListener>())
            {
                gameManager.RegisterListener(listener);
            }
        }
    }
}