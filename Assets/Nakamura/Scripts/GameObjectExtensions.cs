using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectExtensions
{
    /// <summary>
    /// �V�[������IInitialize���p�������I�u�W�F�N�g�̃��X�g��Ԃ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T[] FindObjectOfInterfaces<T>() where T : class
    {
        List<T> list = new List<T>();
        foreach (var n in GameObject.FindObjectsOfType<Component>())
        {
            var component = n as T;
            if (component != null)
            {
                list.Add(component);
            }
        }
        T[] ret = new T[list.Count];
        int count = 0;
        foreach (T component in list)
        {
            ret[count] = component;
            count++;
        }
        return ret;
    }
}
