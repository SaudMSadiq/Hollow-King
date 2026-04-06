using UnityEngine;
using TMPro;
using System.Collections;

public class EndDialogue : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    [Header("Dialogue")]
    public string[] lines;
    public float typingSpeed = 0.05f;
    public float delayBetweenLines = 1.5f;

    private void Start()
    {
        dialoguePanel.SetActive(true);
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        foreach (string line in lines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(delayBetweenLines);
        }

        EndDialogueSequence();
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogueSequence()
    {
        dialoguePanel.SetActive(false);
    }
}