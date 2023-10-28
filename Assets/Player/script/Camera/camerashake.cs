using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Drag your Cinemachine Virtual Camera here
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.15f;

    private Vector3 originalCameraPosition;
    
    private void Start()
    {
        if (virtualCamera != null)
        {
            originalCameraPosition = virtualCamera.transform.localPosition;
        }
    }

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitCircle * shakeIntensity;
            Vector3 newPos = originalCameraPosition + randomOffset;

            virtualCamera.transform.localPosition = Vector3.Lerp(virtualCamera.transform.localPosition, newPos, Time.deltaTime * 10f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        virtualCamera.transform.localPosition = originalCameraPosition;
    }
}
