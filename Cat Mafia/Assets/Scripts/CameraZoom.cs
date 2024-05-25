using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoom;
    private float originalZoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 1f;
    private float maxZoom = 3f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    private bool isZooming = false;
    private bool isCooldown = false;

    [SerializeField] private Camera cam;

    private void Start()
    {
        originalZoom = cam.orthographicSize;
        zoom = originalZoom;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            zoom -= scroll * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        }

        if (Input.GetKeyDown(KeyCode.D) && !isCooldown)
        {
            StartCoroutine(ZoomSkill());
        }
    }

    private IEnumerator ZoomSkill()
    {
        isCooldown = true;
        isZooming = true;

        // Zoom out
        float targetZoom = maxZoom;
        while (Mathf.Abs(cam.orthographicSize - targetZoom) > 0.01f)
        {
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref velocity, smoothTime);
            yield return null;
        }

        cam.orthographicSize = targetZoom;

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Return to original zoom
        while (Mathf.Abs(cam.orthographicSize - originalZoom) > 0.01f)
        {
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, originalZoom, ref velocity, smoothTime);
            yield return null;
        }

        cam.orthographicSize = originalZoom;
        isZooming = false;

        // Start cooldown
        yield return new WaitForSeconds(7f);
        isCooldown = false;
    }
}
