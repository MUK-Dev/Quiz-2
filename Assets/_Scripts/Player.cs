using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 3f;
    [SerializeField] private GameObject curvePrefab;
    [SerializeField] private Transform shootingPoint;

    private Camera cam;
    private Rigidbody rb;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMovement();
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(curvePrefab, shootingPoint.position, shootingPoint.transform.rotation);
        }
    }

    private void PlayerMovement()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
        Quaternion targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Vector3 motion = input.normalized * speed;
        rb.AddForce(motion, ForceMode.Impulse);
    }
}
