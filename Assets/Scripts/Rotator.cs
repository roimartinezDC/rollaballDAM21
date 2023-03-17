using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private int _rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotationSpeed));
    }
}
