using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RequestToSega : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string Accrue(float score, float coins, float time);

    [DllImport("__Internal")]
    private static extern string GetAccounts();

    private float totalTime;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        GetAccounts();
        InvokeRepeating("Request", 0, 240);
    }

    public void Request() =>
        Accrue(0, 0, Mathf.Round(totalTime));

    private void FixedUpdate() =>
        totalTime += Time.deltaTime;
}
