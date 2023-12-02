using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoundEffect : MonoBehaviour
{
    public float delay = 1f;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, delay);
    }
}
