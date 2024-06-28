using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public void SceneSwith(int index)
    {
        SceneManager.LoadScene(index);
    }
}
