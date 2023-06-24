using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCloud : MonoBehaviour
{
    public async void Awake()
    {
        await Authentication.LoginAnonymously();
    }
}
