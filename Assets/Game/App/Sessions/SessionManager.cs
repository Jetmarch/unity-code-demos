using System.Collections.Generic;


namespace Game.App.Sessions
{
    public class SessionManager
    {
        private readonly List<SessionData> _sessions;
        
        private SessionData _currentSession;
        
        public SessionManager(List<SessionData> sessions)
        {
            _sessions = sessions;
        }

        public void StartSession()
        {
            var session = new SessionData();
            session.StartSession();
            _currentSession = session;
            _sessions.Add(session);
        }

        public void EndSession()
        {
            _currentSession.EndSession();
            //Save sessions
        }

        public IReadOnlyList<SessionData> GetSessions()
        {
            return _sessions;
        }
    }
}