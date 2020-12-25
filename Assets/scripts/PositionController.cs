using UnityEngine;

public class PositionController : MonoBehaviour
{
    private Transform PlayerTransform;
    private Transform CameraTransform;
    private SpriteRenderer PlayerSpriteRenderer;
    [SerializeField]private float speed;

    private void Start()
    {
        PlayerTransform = this.gameObject.GetComponent<Transform>();
        CameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
        PlayerSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void ChangeFlip(bool ToRight)
    {
        PlayerSpriteRenderer.flipX = ToRight;
    }

    private void Move(float OnX, float OnY)
    {
        OnX *= speed;          OnY *= speed;
        OnX *= Time.deltaTime; OnY *= Time.deltaTime;

        Vector3 Position_Now = new Vector3(PlayerTransform.position.x + OnX, 
                                           PlayerTransform.position.y + OnY, 
                                           PlayerTransform.position.z);

        PlayerTransform.position = Position_Now;
        Position_Now.z = CameraTransform.position.z;

        CameraTransform.position = Position_Now;

        ChangeFlip(OnX < 0);
    }

    private void Update()
    {
        float ToLeft_Or_Right = Input.GetAxis("Horizontal");
        float ToUp_Or_Down = Input.GetAxis("Vertical");

        Move(ToLeft_Or_Right, ToUp_Or_Down);
    }
}
