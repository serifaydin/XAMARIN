namespace App1.ProjectManager
{
    public class DefaultManager
    {
        private static DefaultManager _defaultManager;
        static object lockObject = new object();

        private DefaultManager() { }

        public static DefaultManager CreateAsSingleton()
        {
            lock (lockObject)
                return _defaultManager ?? (_defaultManager = new DefaultManager());
        }

        public Models.User LoginAction(Models.User model)
        {
            return model;
        }
    }
}