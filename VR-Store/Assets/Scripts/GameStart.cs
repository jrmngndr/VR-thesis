using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public delegate void StartTrigger();
    public static event StartTrigger OnStartTrigger;

    private void OnTriggerEnter(Collider other)
    {
        OnStartTrigger();
    }
}
