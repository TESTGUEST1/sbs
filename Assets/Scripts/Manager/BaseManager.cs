using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager<T> : MonoBehaviour where T : UnityEngine.Object
{
    //SingleTon Pattern
    //언제 어디서든 접근하고 싶다. (하나만 생성되는 녀석)
    public static T Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = FindObjectOfType<T>(); // T가 믿음직스러운 타입인지 알려줘야 한다.
            return _Instance;
        }
    }
    private static T _Instance;
}
