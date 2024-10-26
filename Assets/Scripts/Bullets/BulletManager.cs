using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class BulletManager : MonoBehaviour, IGameFixedUpdateListener, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        private BulletFactory _bulletFactory;
        
        [Inject]
        private void Construct(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }
        
        public void OnPause()
        {
            foreach (var bullet in _bulletFactory.ActiveBullets)
            {
                bullet.StopMove();
            }
        }

        public void OnResume()
        {
            foreach (var bullet in _bulletFactory.ActiveBullets)
            {
                bullet.ResumeMove();
            }
        }

        public void OnFinish()
        {
            foreach (var bullet in _bulletFactory.ActiveBullets)
            {
                bullet.StopMove();
            }
        }

        public void OnFixedUpdate(float fixedDelta)
        {
            foreach (var bullet in _bulletFactory.ActiveBullets)
            {
                bullet.Move(fixedDelta);
            }
        }
    }
}