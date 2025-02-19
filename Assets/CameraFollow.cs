using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float xMin, xMax;
    private float camY,camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;
    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;

    private void Start()
    {
        if (mapBounds != null){
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        }
        else{
            xMin = float.MinValue;
            xMax = float.MaxValue;
        }
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(camX, this.transform.position.y, this.transform.position.z), smoothSpeed);
        this.transform.position = smoothPos;
        
        
    }
}
