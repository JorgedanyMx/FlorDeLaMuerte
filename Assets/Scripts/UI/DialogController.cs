using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private GameEvent SFXDialog;
    [SerializeField] private DialogCanvasController dialogCanvasController;
    // Start is called before the first frame update

    private bool isFirstTime = true;
    private bool isDialogActive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(!isFirstTime) return;
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
