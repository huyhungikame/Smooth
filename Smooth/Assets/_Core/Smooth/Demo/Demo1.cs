using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1 : MonoBehaviour
{
    public void Action(Action action)
    {
        action.Invoke();
    }
}