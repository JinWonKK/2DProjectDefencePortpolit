using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class IntroScene : MonoBehaviour
{
    [SerializeField]
    private GameObject          logoObj;

    [SerializeField]
    private AudioMixer audioMixer;

    private void Awake()
    {
        //audioMixer.SetFloat(Sound_Type.BGM.ToString(), 0f);
        LeanTween.moveLocalY(logoObj.gameObject, 0f, 3f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.moveLocalX(logoObj.gameObject, 0f, 3f).setEase(LeanTweenType.easeInSine);
        LeanTween.rotate(logoObj, Vector3.zero, 3f);
        Invoke("NextScene", 3.5f);
    }

    private void NextScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
