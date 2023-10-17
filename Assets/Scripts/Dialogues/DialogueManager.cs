using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // подключаем библиотеку

// данный скрипт это работа над самими предложениями в диалогах
public class DialogueManager : DialogueTrigger
{
    public Text dialogueText; // текст имени
    public Text nameText; // текст диалога

    // указываем в аниматоре наших двух окон
    public Animator boxAnim;
    public Animator startAnim;

    private Queue<string> sentences; // создаем очередь наших предложений

    private void Start()
    {
        sentences = new Queue<string>(); // присваиваем нашим предложениям новую очередь
    }

    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true); // открываем наш DialogueBox
        startAnim.SetBool("startOpen", false); // и соответственно закрываем наше стартовое окно

        nameText.text = dialogue.name; // указываем имя нашего персонажа
        sentences.Clear(); // очищаем наши предложения

        // делаем для наших предложений цикл foreach
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); // ставим в очередь каждое наше предложение
        }
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        // если предложений в очереди у нас осталось 0, то
        if (sentences.Count == 0)
        {
            EndDialogue(); // заканчиваем диалог
            return;
        }
        string sentence = sentences.Dequeue(); // останавливаем корутины и начинаем новую
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // анимируем наши диалоги с помощью интерфейса -> "они будут вылетать последовательно"
    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = ""; // указываем текст нашего диалога, который находится внутри кавычек
        foreach (char letter in sentence.ToCharArray()) // указываем цикл для каждой буквы в предложении
        {   // то есть с каждой буквой мы будем прибавлять еще одну букву
                dialogueText.text += letter;
                yield return null;
        }
    }
    public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
    }
}
