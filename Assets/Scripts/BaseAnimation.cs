using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimation : ScriptableObject
{
    [SerializeField] public float duration;

    public virtual void Animate(Transform visual){}
}