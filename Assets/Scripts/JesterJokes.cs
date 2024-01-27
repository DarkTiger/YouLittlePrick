using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterJokes : MonoBehaviour
{
    [SerializeField] AudioClip jokesClip;
    [SerializeField] AudioClip bagClip;
    [SerializeField] AudioClip saxClip;
    [SerializeField] AudioClip lampClip;


    [Header("ObjectToDisable")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject UI;
    

    [SerializeField] Animator animator;

    

    public void StartJokesAnimation(MissionObjectEventType jokeObject)
    {
        switch (jokeObject)
        {
            case MissionObjectEventType.Bag:
                animator.SetTrigger("Bag");
                break;
            case MissionObjectEventType.Lamp:
                animator.SetTrigger("Lamp");
                break;
            case MissionObjectEventType.Fax:
                animator.SetTrigger("Sax");
                break;
            case MissionObjectEventType.Jokes:
                animator.SetTrigger("DirtyJokes");
                break;
        }
    }

    public void StartEvent()
    {
        player.SetActive(false);
        UI.SetActive(false);
    }

    public void EndEvent()
    {
        player.SetActive(true);
        UI.SetActive(true);

        gameObject.SetActive(false);
    }

}
