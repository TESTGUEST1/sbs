using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager<T> : MonoBehaviour where T : UnityEngine.Object
{
    //SingleTon Pattern
    //���� ��𼭵� �����ϰ� �ʹ�. (�ϳ��� �����Ǵ� �༮)
    public static T Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = FindObjectOfType<T>(); // T�� ������������ Ÿ������ �˷���� �Ѵ�.
            return _Instance;
        }
    }
    private static T _Instance;
}
