using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string[] lines;
    private int index;
    public float textSpeed;
    bool endofDialogue = false;
    // bool playerExited = false;

    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            if(dialogText.text == lines[index]) {
                NextLine();
            } else {
                StopAllCoroutines();
                dialogText.text = lines[index];
            }
        }
        
    }

    public void StartDialogue() {
        index = 0;
        dialogBox.SetActive(true);
        endofDialogue = false;
        dialogText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            dialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            endofDialogue = true;
            dialogBox.SetActive(false);
        }
    }

    public int getIndex() {
        return index;
    }

    public bool checkEnd() {
        return endofDialogue;
    }
}
