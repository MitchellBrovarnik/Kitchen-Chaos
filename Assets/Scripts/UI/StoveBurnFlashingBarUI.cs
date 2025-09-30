using UnityEngine;

public class StoveBurnFlashingBarUI : MonoBehaviour
{

    private const string IS_FLASHING = "IsFlashing";
    private Animator animator;
    [SerializeField] private StoveCounter stoveCounter;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        animator.SetBool(IS_FLASHING, false);
    }
    private void Start()
    {
        stoveCounter.OnProgressChanged += stoveCounter_OnProgressChanged;
    }

    private void stoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProgressAmount = .5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

        animator.SetBool(IS_FLASHING, show);

    }
}
