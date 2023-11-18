using UnityEngine;

public class Curve : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 10f;
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, 0.25f);
    }

    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + (scaleFactor * Time.deltaTime), transform.localScale.y, transform.localScale.z);
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
