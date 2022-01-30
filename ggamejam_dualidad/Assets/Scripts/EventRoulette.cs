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
        "Teletransportación",
        "Evento testeo",
        "Evento random"
    };

    public float rouletteTempo = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartRoulette()
    {
        StartCoroutine("RandomTextCoroutine");
    }

    void ExecuteRandomEvent()
    {
        Event[] events =
        {
            new CharactersPositionChangeEvent(),
            new TestEvent()
        };

        int randomIndex = Random.Range(0, events.Length);

        if (eventText)
        {
            eventText.text = eventNames[randomIndex];
        }

        events[randomIndex].Execute(match);
        match.player.canMove = true;
        match.player.actions=5;
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
