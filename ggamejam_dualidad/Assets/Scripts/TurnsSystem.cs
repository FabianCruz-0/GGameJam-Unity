using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnsSystem : MonoBehaviour
{
    public int TurnNumber;
    Text TextTurnNumber;

    void Start()
    {
        TurnNumber = 0;
        TextTurnNumber = GameObject.Find("TurnNumber").GetComponent<Text>();
    }

    void Update()
    {
        TextTurnNumber.text = "Turn Number: "+TurnNumber;
    }

}
