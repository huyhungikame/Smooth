using System;
using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class Demo : MonoBehaviour
{
    int content = 4;
    private void Update()
    {
        Test.Action(this,(data) => data.TestContent());
    }

    private void TestContent()
    {
        content += 5;
    }
}

public static class Test
{
    public static void Action<T>(T content, Action<T> action)
    {
        action.Invoke(content);
    }
}