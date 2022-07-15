using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

	public float delay;
	public TextMeshProUGUI dialogueText;

	private Queue<string> sentences;
    // Start is called before the first frame update
    private void Awake()
    {
    	sentences = new Queue<string>();
        
    }

    public void StartDialogue (Dialogue dialogue)
    {

    	sentences.Clear();

    	foreach (string sentence in dialogue.sentences)
    	{
    		sentences.Enqueue(sentence);
    	}

    	DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
    	if (sentences.Count == 0)
    	{
    		EndDialogue();
    		return;
    	}

    	string sentence = sentences.Dequeue();
    	StopAllCoroutines();
    	StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
    	dialogueText.text = "";
    	foreach(char letter in sentence.ToCharArray())
    	{
    		dialogueText.text += letter;
    		yield return new WaitForSeconds(delay);
    	}
    }


    void EndDialogue()
    {
    	SceneManager.LoadScene("gameplay");
    }
}
