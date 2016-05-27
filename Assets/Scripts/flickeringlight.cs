using UnityEngine;
using System.Collections;

public class flickeringlight : MonoBehaviour {

    Light m_Intensity;
    public float m_IntensitySpeed;

	// Use this for initialization
	void Start () {
        m_Intensity =  GetComponent<Light>();
        StartCoroutine(FlickeringStart());
	}
	
    IEnumerator FlickeringStart ()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        StartCoroutine(Flickering());
        
    }

    IEnumerator Flickering ()
    {
        while (true)
        {
            m_Intensity.intensity += m_IntensitySpeed;

            if (m_Intensity.intensity > 0.4f)
            {
                m_IntensitySpeed = m_IntensitySpeed * -1;
            }

            if (m_Intensity.intensity < 0.1f)
            {
                m_IntensitySpeed = m_IntensitySpeed * -1;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
