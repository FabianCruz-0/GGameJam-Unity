using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : Event
{
    public override void Execute(Match match)
    {
        Debug.Log("Evento de testeo");
    }
}
