using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    [SerializeField] private GameEvent  buttonEvent;
    private Animation  anim;
    private string clipName = "ButtonAnimation";
    private bool isPlaying = false;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if(anim!=null && anim[clipName]!=null && isPlaying)
        {
            anim[clipName].time += Time.unscaledDeltaTime;
            if(anim[clipName].time >= anim[clipName].length)
            {
                isPlaying = false;
                anim[clipName].time = 0.0f;
                anim.Stop();
                buttonEvent.Raise();
            }
        }
        
    }

    public void playAnimation()
    {
        isPlaying = true;
        anim.Play(clipName);
    }
}
