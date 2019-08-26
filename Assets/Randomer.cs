using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomer : MonoBehaviour
{
    public static float herospeed;
    private void Awake()
    {
        herospeed = Random.Range(3f, 15f);
    }
}
