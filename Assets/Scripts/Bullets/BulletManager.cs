namespace ShootEmUp
{
    public sealed class BulletManager : IGameFixedUpdateListener, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        private readonly BulletFactory _bulletFactory;
        
        public BulletManager(BulletFactory bulletFactory)
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