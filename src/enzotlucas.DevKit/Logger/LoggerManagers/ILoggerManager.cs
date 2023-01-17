namespace enzotlucas.DevKit.Logger.LoggerManagers
{
    /// <summary>
    /// Provides a custom logger manager
    /// </summary>
    public interface ILoggerManager : IDisposable
    {
        /// <summary>
        /// Saves the log
        /// </summary>
        /// <param name="log">The log that will be saved</param>
        public void Log(Log log);
    }
}
