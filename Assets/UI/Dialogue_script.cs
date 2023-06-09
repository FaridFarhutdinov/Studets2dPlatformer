using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_script : MonoBehaviour
{
    public GameObject panelDialogue;
    public Text dialogue;
    public string[] message;
    private int index = 0;
    bool flag = true;

    void Start()
    {
        panelDialogue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && flag == true) {
            panelDialogue.SetActive(true);
            InvokeRepeating("Tiping", 0.5f, 3.0f);
        }
    }

    private void Tiping()
    {
        dialogue.text = message[index];
        index++;
        if (message[index] == "0")
        {
            CancelInvoke();
            panelDialogue.SetActive(false);
            flag = false;
            index = 0;
        }
    }


}
