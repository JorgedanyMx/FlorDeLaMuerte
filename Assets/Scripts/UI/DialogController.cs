using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private GameEvent SFXDialog;
    [SerializeField] private DialogCanvasController dialogCanvasController;
    [SerializeField] private bool secondPartGame = false;
    // Start is called before the first frame update

    private bool isFirstTime = true;
    private bool isDialogActive = false;
    private bool isActive;
    void Start()
    {
        isActive=!secondPartGame;
    }

    public void SwitchActive()
    {
        isActive = !isActive;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            ShowDialog();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            HideDialog();
        }
    }

    private void ShowDialog() {
        if(!isFirstTime || !isActive) return;
        isFirstTime = false;
        isDialogActive = true;
        SFXDialog.Raise();
        dialogCanvasController.ShowDialog();

    }

    private void HideDialog() {
        if(!isDialogActive) return;
        isDialogActive = false;
    }
}
