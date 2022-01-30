using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventRoulette : MonoBehaviour
{
    public Match match;
    public Text eventText;

    public string[] eventNames =
    {
        "Evento de testeo",
        "Evento random",
        "Evento random 2"
    };

    public float rouletteTempo = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            StartRoulette();
        }
    }

    public void StartRoulette()
    {
        StartCoroutine("RandomTextCoroutine");
    }

    void ExecuteRandomEvent()
    {
        Event[] events =
        {
            new TestEvent()
        };

        int randomIndex = Random.Range(0, events.Length - 1);

        events[randomIndex].Execute(match);
    }

    IEnumerator RandomTextCoroutine()
    {
        while(rouletteTempo > 0f)
        {
            rouletteTempo -= .2f;

            // Random event name to display
            int randomIndex = Random.Range(0, eventNames.Length - 1);
            if (eventText)
            {
                eventText.text = eventNames[randomIndex];
            }

            yield return new WaitForSeconds(.2f);
        }

        rouletteTempo = 5f;
        ExecuteRandomEvent();
    }
}
