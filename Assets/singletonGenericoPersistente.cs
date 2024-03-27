using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletonGenericoPersistente<T> : MonoBehaviour
    where T : Component
{

    private static T _instance;

    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
