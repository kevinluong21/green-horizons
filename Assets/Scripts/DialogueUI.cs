using System.Collections;
using UnityEngine;
using TMPro;
 
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        Debug.Log("running show dialog");
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        Debug.Log("running step through dialogue");
        foreach(string dialogue in dialogueObject.Dialogue)
        {
            Debug.Log(dialogue);
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
