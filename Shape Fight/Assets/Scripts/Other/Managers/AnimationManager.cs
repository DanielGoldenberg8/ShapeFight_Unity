using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator camAnim;

    public static AnimationManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ShakeAnim()
    {
        camAnim.SetTrigger("shake");
    }
}
