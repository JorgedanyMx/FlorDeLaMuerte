using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDoorController : MonoBehaviour
{
    private Animator animator;
    private bool mouseIsHovering = false;

    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (mouseIsHovering && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("MouseClick");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            mouseIsHovering=true;
            animator.SetTrigger("MouseHoverIn");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            mouseIsHovering=false;
            animator.SetTrigger("MouseHoverOut");
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
