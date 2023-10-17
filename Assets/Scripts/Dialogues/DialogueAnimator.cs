using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// данный скримт работает над анимацией диалога, когда мы подходим к персонажу
public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnim.SetBool("startOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim.SetBool("startOpen", false);
        dm.EndDialogue(); // заканчиваем диалог
    }
}
