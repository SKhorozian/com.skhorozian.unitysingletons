using UnityEngine;

// Credit to https://github.com/UnityCommunity/UnitySingleton
public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
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

            _instance = FindObjectOfType<T> ();
            if (_instance != null) return _instance;
            
            var obj = new GameObject {
                name = typeof ( T ).Name
            };
            
            _instance = obj.AddComponent<T> ();
            return _instance;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    protected virtual void Awake ()
    {
        if ( _instance == null )
        {
            _instance = this as T;
            if (transform.parent == null)
                DontDestroyOnLoad ( gameObject );
        }
        else
        {
            Destroy ( gameObject );
        }
    }

    #endregion
	
}