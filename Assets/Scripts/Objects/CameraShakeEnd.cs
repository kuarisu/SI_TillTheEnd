using UnityEngine;
using System.Collections;

public class CameraShakeEnd : MonoBehaviour
{
    public static CameraShakeEnd instance = null;
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 3f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 0.1f;
	
	Vector3 originalPos;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
	{
		originalPos = camTransform.localPosition;
	}

    public void ScreenShakeStart()
    {
        StartCoroutine(ScreenShake());
    }

	IEnumerator ScreenShake()
	{
		while (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
            yield return new WaitForEndOfFrame();
		}

		shakeDuration = 0.1f;
		camTransform.localPosition = originalPos;

        yield return null;
	}
}
