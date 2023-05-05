using UnityEngine.SceneManagement;
using UnityEngine;

public class EndLocation : MonoBehaviour
{
    public string name; 
    void OnTriggerEnter2D(Collider2D other) { SceneManager.LoadScene(name); }
}
