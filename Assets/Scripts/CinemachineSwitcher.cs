using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction action;
    private Animator animator;

    public static bool flag = true;
    
    // Since we only using 2 cameras we can just set this to a bool
    private bool femaleCamera = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        action.performed += _ => SwitchState();
    }

    private void SwitchState()
    {
        if (femaleCamera)
        {
            flag = true;
            animator.Play("FemaleCamera");
        }
        else
        {
            flag = false;
            animator.Play("MaleCamera");
        }

        // Switch bool over.
        femaleCamera = !femaleCamera;
    }
}
