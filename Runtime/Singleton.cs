public abstract class Singleton<T> where T : new()
{
	
    #region Fields

    /// <summary>
    /// The instance.
    /// </summary>
    private static T _instance;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static T instance
    {
        get
        {
            if (_instance != null) return _instance;
            
            _instance = new T ();
            
            return _instance;
        }
    }

    #endregion
}