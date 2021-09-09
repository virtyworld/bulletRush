using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TargetIndicator : MonoBehaviour
{
    [SerializeField] private Image targetIndicatorImage;
    [SerializeField] private Image offScreenTargetIndicator;
    [SerializeField] private float outOfSightOffset = 20f;
    [SerializeField] private float minDistanceBlinkinAnimation = 10f;
    [SerializeField] private float maxDistanceBlinkinAnimation = 70f;

    private Animator animator;

    private float outOfSighOffset
    {
        get { return outOfSightOffset; }
    }

    private GameObject target;
    private Camera mainCamera;
    private RectTransform canvasRect;
    private RectTransform rectTransform;
    private Transform playerTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    public void InitialiseTargetIndicator(GameObject target, Camera mainCamera, Canvas canvas)
    {
        this.target = target;
        this.mainCamera = mainCamera;
        canvasRect = canvas.GetComponent<RectTransform>();

        target.GetComponent<Enemy>().TargetIndicator = gameObject;
    }

    public void UpdateTargetIndicator()
    {
        SetIndicatorPosition();
    }

    private void SetIndicatorPosition()
    {
        Vector3 indicatorPosition = mainCamera.WorldToScreenPoint(target.transform.position);

        if (indicatorPosition.z >= 0f & indicatorPosition.x <= canvasRect.rect.width * canvasRect.localScale.x &
            indicatorPosition.y <= canvasRect.rect.height * canvasRect.localScale.x & indicatorPosition.x >= 0f &
            indicatorPosition.y >= 0f)
        {
            indicatorPosition.z = 0f;
            TargetOutOfSight(false, indicatorPosition);
        }
        else if (indicatorPosition.z >= 0f)
        {
            indicatorPosition = OutOfRangeIndicatorPositionB(indicatorPosition);
            TargetOutOfSight(true, indicatorPosition);
        }
        else
        {
            indicatorPosition *= -1f;
            indicatorPosition = OutOfRangeIndicatorPositionB(indicatorPosition);
            TargetOutOfSight(true, indicatorPosition);
        }

        rectTransform.position = indicatorPosition;
    }

    private void TargetOutOfSight(bool oos, Vector3 indicatorPosition)
    {
        if (oos)
        {
            if (offScreenTargetIndicator.gameObject.activeSelf == false)
            {
                offScreenTargetIndicator.gameObject.SetActive(true);
            }

            if (targetIndicatorImage.isActiveAndEnabled == true)
            {
                targetIndicatorImage.enabled = false;
            }

            offScreenTargetIndicator.rectTransform.rotation =
                Quaternion.Euler(RotationOutOfSighTargetIndicator(indicatorPosition));
        }
        else
        {
            if (offScreenTargetIndicator.gameObject.activeSelf == true)
            {
                offScreenTargetIndicator.gameObject.SetActive(false);
            }

            if (targetIndicatorImage.isActiveAndEnabled == false)
            {
                targetIndicatorImage.enabled = true;
            }
        }
    }

    private Vector3 RotationOutOfSighTargetIndicator(Vector3 indicatorPosition)
    {
        Vector3 canvasCenter = new Vector3(canvasRect.rect.width / 2f, canvasRect.rect.height / 2f, 0f) *
                               canvasRect.localScale.x;
        float angle = Vector3.SignedAngle(Vector3.up, indicatorPosition - canvasCenter, Vector3.forward);

        return new Vector3(0f, 0f, angle);
    }

    private Vector3 OutOfRangeIndicatorPositionB(Vector3 indicatorPosition)
    {
        indicatorPosition.z = 0f;

        Vector3 canvasCenter = new Vector3(canvasRect.rect.width / 2f, canvasRect.rect.height / 2f, 0f) *
                               canvasRect.localScale.x;

        float divX = (canvasRect.rect.width / 2f - outOfSighOffset) / Mathf.Abs(indicatorPosition.x);
        float divY = (canvasRect.rect.height / 2f - outOfSighOffset) / Mathf.Abs(indicatorPosition.y);

        if (playerTransform)
        {
            float dist = Vector3.Distance(target.transform.position, playerTransform.position);
            BlinkinArrowAnimation(dist);
        }


        if (divX < divY)
        {
            float angle = Vector3.SignedAngle(Vector3.right, indicatorPosition, Vector3.forward);
            indicatorPosition.x = Mathf.Sign(indicatorPosition.x) * (canvasRect.rect.width * 0.5f - outOfSighOffset) *
                                  canvasRect.localScale.x;
            indicatorPosition.y = Mathf.Tan(Mathf.Deg2Rad * angle) * indicatorPosition.x;
        }
        else
        {
            float angle = Vector3.SignedAngle(Vector3.up, indicatorPosition, Vector3.forward);
            indicatorPosition.y = Mathf.Sign(indicatorPosition.y) * (canvasRect.rect.height / 2f - outOfSighOffset) *
                                  canvasRect.localScale.y;
            indicatorPosition.x = -Mathf.Tan(Mathf.Deg2Rad * angle) * indicatorPosition.y;
        }

        indicatorPosition += canvasCenter;
        return indicatorPosition;
    }

    private void BlinkinArrowAnimation(float dist)
    {
        if (dist > minDistanceBlinkinAnimation && dist < maxDistanceBlinkinAnimation)
        {
            animator.SetBool("Closest", true);
        }
        else
        {
            animator.SetBool("Closest", false);
        }
    }
}