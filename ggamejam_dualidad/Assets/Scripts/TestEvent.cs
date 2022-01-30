using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : Event
{
    public override void Execute(Match match, MonoBehaviour monoBehaviour)
    {
        Debug.Log("Evento de testeo");
    }
}
