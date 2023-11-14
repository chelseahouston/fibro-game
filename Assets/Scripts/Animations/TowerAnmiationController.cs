using UnityEngine;


// author: chelsea houston
// date last midified: 14/11/23

public class TowerAnimationController : MonoBehaviour
{
    public Animator animator;
    public GameObject tower;
    public bool isAnimating;

    void Start()
    {
        ChangeView();
    }

    void OnEnable()
    {
        ChangeView();
    }

    public void ChangeView()
    {
        isAnimating = (PlayerPrefs.GetInt("TowerPlaying") != 0);
        animator = tower.GetComponent<Animator>();
        animator.keepAnimatorStateOnDisable = true;
        animator.SetBool("Play", isAnimating);
    }

    public void OnClick()
    {
        isAnimating = !isAnimating;
        PlayerPrefs.SetInt("TowerPlaying", (isAnimating ? 1 : 0));
        animator.SetBool("Play", isAnimating);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("TowerPlaying", (false ? 1 : 0));
    }

}
