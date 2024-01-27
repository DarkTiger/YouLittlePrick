using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public int item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<inventory>())
        dialogueSystem.PlayDialogue(dialogueSystem.cookList, item);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<inventory>())
            dialogueSystem.StopDialogue();
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
}
