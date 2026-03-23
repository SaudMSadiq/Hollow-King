using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCDialogue", menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
   public string npcName;
   public Sprite npcPortrait;
   public string[] dialogueLines;
   public bool[] autoProgressLines;    // Optional: Array to determine if dialogue should auto-progress after each line
   public float autoProgressDelay = 1.5f; // Optional: Delay before auto-progressing to the next line
   public float typingSpeed = 0.1f;

   //public AudioClip voiceSound; // Optional: Sound effect for typing
   //public float voicePitch = 1.0f; // Optional: Pitch for the voice sound
   


}
