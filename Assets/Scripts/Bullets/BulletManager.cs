using UnityEngine;

namespace ShootEmUp
{
    public class BulletManager : MonoBehaviour, IGameFixedUpdateListener, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        [SerializeField] private BulletFactory _bulletFactory;
        private void Start()
        {
            IGameListener.Register(this);
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