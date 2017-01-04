using UnityEngine;
using System.Collections;

[ExecuteInEditMode, RequireComponent(typeof(Camera))]
public class NavigationFPS : MonoBehaviour {
    public float speed = 5.0f;
    public float minX = -360.0f;
    public float maxX = 360.0f;

    public float minY = -45.0f;
    public float maxY = 45.0f;

    public float sensX = 100.0f;
    public float sensY = 100.0f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Time.deltaTime * Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Time.deltaTime * Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Quaternion qqq = transform.rotation;
            Vector3 dir = qqq * Vector3.forward;
            Vector3 pos = transform.position;
            Debug.Log(dir);
            pos.x += dir.x * Time.deltaTime * speed;
            pos.z += dir.z * Time.deltaTime * speed;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Quaternion qqq = transform.rotation;
            Vector3 dir = qqq * Vector3.forward;
            Vector3 pos = transform.position;
            Debug.Log(dir);
            pos.x -= dir.x * Time.deltaTime * speed;
            pos.z -= dir.z * Time.deltaTime * speed;
            transform.position = pos;
        }
    }
}
