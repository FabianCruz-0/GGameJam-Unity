using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event
{
    public bool canHappen = true;
    public abstract void Execute(Match match, MonoBehaviour monoBehaviour = null);
}
