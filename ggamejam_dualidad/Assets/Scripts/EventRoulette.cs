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
        "Cambio de perspectiva",
    };

    readonly Event[] events =
    {
        new CharactersPositionChangeEvent(),
        new CameraRotationEvent()
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
        int randomIndex = Random.Range(0, events.Length);

        while (!events[randomIndex].canHappen)
        {
            randomIndex = Random.Range(0, events.Length);
        }

        if (eventText)
        {
            eventText.text = eventNames[randomIndex];
        }

        events[randomIndex].Execute(match, this);
    }

    IEnumerator RandomTextCoroutine()
    {
        while(rouletteTempo > 0f)
        {
            rouletteTempo -= .2f;
            rouletteTempo -= Time.deltaTime;

            // Random event name to display
            int randomIndex = Random.Range(0, eventNames.Length - 1);
            if (eventText)
            {
                eventText.text = eventNames[randomIndex];
            }

            yield return new WaitForSeconds(.1f);
        }

        rouletteTempo = 5f;
        ExecuteRandomEvent();
    }
}
