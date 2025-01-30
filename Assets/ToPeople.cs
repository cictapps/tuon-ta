using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPeople : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ToPeopleScene()
    {
        SceneManager.LoadScene("hayag_QandA.People");
    }
}