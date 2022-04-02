using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    private float fadeDuration = 1f;
    [SerializeField]
    private float displayImageDuration = 1f;
    [SerializeField]
    private GameObject playerGameObject;
    [SerializeField]
    private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField]
    private CanvasGroup caughtBackgroundImageCanvasGroup;
    [SerializeField]
    private AudioSource exitAudio;
    [SerializeField]
    private AudioSource caughtAudio;

    private bool m_IsPlayerAtExit = false;
    private bool m_IsPlayerCaught = false;
    private bool m_HasAudioPlayed = false;
    private float m_Timer;

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerGameObject)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void PlayerCaught()
    {
        m_IsPlayerCaught = true;
    }
}
