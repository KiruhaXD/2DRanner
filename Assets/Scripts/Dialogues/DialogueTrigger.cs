using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// этот скрипт вызывает сам диалог
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // указываем наш диалог

    // создаем функцию, которая будет вызывать наш диалог
    public void TriggerDialogue() 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


}
