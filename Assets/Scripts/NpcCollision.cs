using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollision : MonoBehaviour
{
    
    public GameObject exclamationMark;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] private GameObject profilePic;
    private bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        exclamationMark.SetActive(false);
        dialogue.SetActive(false);
        profilePic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (collided && Input.GetKeyDown(KeyCode.Return))
        {
            exclamationMark.SetActive(false);
            dialogue.SetActive(true);
            dialogue.GetComponent<DialogueUI>().ShowDialogue(testDialogue);
            profilePic.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("npc hit!!!");
        exclamationMark.SetActive(true);
        collided = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        exclamationMark.SetActive(false);
        collided = false;
        profilePic.SetActive(false);
    }
}
