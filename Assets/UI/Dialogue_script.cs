using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_script : MonoBehaviour
{
    public GameObject panelDialogue;
    public Text dialogue;
    public string[] message;
    private int index = 0;

    void Start()
    {
        panelDialogue.SetActive(false);
    }

    private void OnCollisionEnter(Collider2D col)
    {
        if (col.tag == "Player") {
            Time.timeScale = 0;
            panelDialogue.SetActive(true);
            InvokeRepeating("Tiping", 0.5f, 3f);
        }

    }

    private void Tiping()
    {
        dialogue.text = message[index];
        index++;
        if (message[index] == null) {
            CancelInvoke();
            Time.timeScale = 0;
        }
    }


}
