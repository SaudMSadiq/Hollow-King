using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class BossDialogue : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public Image portraitImage;

    [Header("Dialogue Data")]
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;
    public float delayBetweenLines = 1f;

    private bool isPlaying = false;

    public void Play()
    {
        if (isPlaying) return;

        // ✅ Show the panel before starting
        if (dialoguePanel != null) dialoguePanel.SetActive(true);

        if (nameText != null) nameText.SetText(npcName);
        if (portraitImage != null) portraitImage.sprite = npcPortrait;

        isPlaying = true; // ✅ Actually set the flag
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        foreach (string line in dialogueLines)
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
        isPlaying = false; // ✅ Reset so it can play again if needed
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
    }
}