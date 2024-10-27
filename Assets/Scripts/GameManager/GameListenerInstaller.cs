using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class GameListenerInstaller : MonoBehaviour
    {
        [Inject]
        private void Construct(GameManager gameManager, IEnumerable<IGameListener> gameListeners)
        {
            foreach (var listener in gameListeners)
            {
                gameManager.RegisterListener(listener);
            }
        }
    }
}