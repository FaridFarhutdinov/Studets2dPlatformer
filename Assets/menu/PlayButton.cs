using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void Play(string name) { SceneManager.LoadScene(name); }
}
