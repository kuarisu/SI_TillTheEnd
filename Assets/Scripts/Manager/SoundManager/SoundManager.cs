using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	#region Members

	[Header("MUSICS")]
	public List<AudioClip> Music = new List<AudioClip>();

	[Header("SOUNDS")]
	public List<AudioClip> Sound= new List<AudioClip>();
	
	[Header("VOICES")]
	public List<AudioClip> Voice = new List<AudioClip>();

	[Header("Sound Listeners")]
	public List<AudioSource> Source = new List<AudioSource>();


    #endregion

    bool m_Ready = false;


	// Use this for initialization
	void Start()
	{
        Debug.Log("SoundManager");
		SoundManagerEvent.onEvent += Play;
	}

	void OnDestroy()
	{
		SoundManagerEvent.onEvent -= Play;
	}

	public void Play(SoundManagerType emt)
	{
		switch (emt)
		{
            case SoundManagerType.GameMusic:
                Source[0].Stop();
                Source[0].clip = Music[0];
                Source[0].Play();
                break;

            case SoundManagerType.MainMusic:
                Source[0].Stop();
                Source[0].clip = Music[1];
                Source[0].Play();
                break;

            case SoundManagerType.Bell:
                Source[1].Stop();
                Source[1].clip = Sound[0];
                Source[1].Play();
                break;

            case SoundManagerType.BellCaught:
                Source[1].Stop();
                Source[1].clip = Sound[1];
                Source[1].Play();
                break;

            case SoundManagerType.Button:
                Source[4].Stop();
                Source[4].clip = Sound[2];
                Source[4].Play();
                break;

            case SoundManagerType.PlayerColision:
                Source[3].clip = Sound[8];
                Source[3].Play();
                break;

            case SoundManagerType.PlayerDeath:
                Source[3].clip = Sound[4];
                Source[3].Play();
                break;

            case SoundManagerType.PlayerJump:
                Source[3].clip = Sound[5];
                Source[3].Play();
                break;

            case SoundManagerType.PlayerMeditation:
                Source[3].clip = Sound[6];
                Source[3].Play();
                break;

            case SoundManagerType.BlockPushed:
                Source[2].clip = Sound[7];
                Source[2].Play();
                break;

            case SoundManagerType.BlockColision:
                Source[2].clip = Sound[3];
                Source[2].Play();
                break;



        }
	}

    IEnumerator DecreaseMoweSound()
    {
        while(Source[2].volume>0.5f)
        {
            Source[2].volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        Source[2].volume = 0.5f;
    }

    IEnumerator DecreaseMoweSoundBig()
    {
        while (Source[2].volume > 0.1f)
        {
            Source[2].volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }

        Source[2].volume = 0.1f;
    }


}
