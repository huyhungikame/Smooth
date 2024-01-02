using System;
using PrimeTween;
using UnityEngine;

public class Demo : MonoBehaviour
{
    private void Start()
    {
        Tween.Position(transform, Vector3.down, 2);
    }
}