using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale : MonoBehaviour
{
    [SerializeField] GameEvent SFXCreditosEvent;
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SFXCreditos()
    {
        SFXCreditosEvent.Raise();
    }
}
