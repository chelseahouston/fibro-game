using UnityEngine;

public class ClickAnimationController : MonoBehaviour
{
    public Animator animator;
    public GameObject animatingObject;
    public bool isAnimating;

    void Start()
    {
        isAnimating = (PlayerPrefs.GetInt("Playing") != 0);
        animator = animatingObject.GetComponent<Animator>();
        animator.keepAnimatorStateOnDisable = true;
        animator.SetBool("Play", isAnimating);
    }

    void OnEnable()
    {
        isAnimating = (PlayerPrefs.GetInt("Playing") != 0);
        animator = animatingObject.GetComponent<Animator>();
        animator.keepAnimatorStateOnDisable = true;
        animator.SetBool("Play", isAnimating);
    }

    public void OnClick()
    {
        isAnimating = !isAnimating;
        PlayerPrefs.SetInt("Playing", (isAnimating ? 1 : 0));
        animator.SetBool("Play", isAnimating);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Playing", (false ? 1 : 0));
    }

}
