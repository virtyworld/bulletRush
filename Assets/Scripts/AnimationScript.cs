using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] private Animator animationPrefab;

    public Animator AnimationPrefab
    {
        get => animationPrefab;
        set => animationPrefab = value;
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}