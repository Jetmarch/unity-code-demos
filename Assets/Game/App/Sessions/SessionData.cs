using System;

namespace Game.App.Sessions
{
    [Serializable]
    public sealed class SessionData
    {
        public Guid Id => _id;
        
        private Guid _id;
        private DateTime _startTime;
        private DateTime _endTime;

        public SessionData()
        {
            _id = Guid.NewGuid();
        }

        public SessionData(Guid id, DateTime startTime, DateTime endTime)
        {
            _id = id;
            _startTime = startTime;
            _endTime = endTime;
        }

        public int GetSessionDurationInSeconds()
        {
            return (_endTime - _startTime).Seconds;
        }

        public void StartSession()
        {
            _startTime = DateTime.Now;
        }

        public void EndSession()
        {
            _endTime = DateTime.Now;
        }
    }
}