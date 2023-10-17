using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ���������� ����������

// ������ ������ ��� ������ ��� ������ ������������� � ��������
public class DialogueManager : DialogueTrigger
{
    public Text dialogueText; // ����� �����
    public Text nameText; // ����� �������

    // ��������� � ��������� ����� ���� ����
    public Animator boxAnim;
    public Animator startAnim;

    private Queue<string> sentences; // ������� ������� ����� �����������

    private void Start()
    {
        sentences = new Queue<string>(); // ����������� ����� ������������ ����� �������
    }

    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true); // ��������� ��� DialogueBox
        startAnim.SetBool("startOpen", false); // � �������������� ��������� ���� ��������� ����

        nameText.text = dialogue.name; // ��������� ��� ������ ���������
        sentences.Clear(); // ������� ���� �����������

        // ������ ��� ����� ����������� ���� foreach
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); // ������ � ������� ������ ���� �����������
        }
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        // ���� ����������� � ������� � ��� �������� 0, ��
        if (sentences.Count == 0)
        {
            EndDialogue(); // ����������� ������
            return;
        }
        string sentence = sentences.Dequeue(); // ������������� �������� � �������� �����
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // ��������� ���� ������� � ������� ���������� -> "��� ����� �������� ���������������"
    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = ""; // ��������� ����� ������ �������, ������� ��������� ������ �������
        foreach (char letter in sentence.ToCharArray()) // ��������� ���� ��� ������ ����� � �����������
        {   // �� ���� � ������ ������ �� ����� ���������� ��� ���� �����
                dialogueText.text += letter;
                yield return null;
        }
    }
    public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
    }
}
