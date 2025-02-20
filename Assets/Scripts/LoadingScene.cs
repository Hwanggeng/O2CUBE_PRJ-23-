using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LoadingScene : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("INTER_1_puzzle");
        operation.allowSceneActivation = false;


        while (!operation.isDone)
        {
            yield return null;

            if(progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value,0.9f,Time.deltaTime);
            }

            else if(operation.progress>=0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            if(progressbar.value >=1f)
            {
                loadtext.text = "Press Space";
            }

            if(Input.GetKeyDown(KeyCode.Space) && progressbar.value>=1f && progressbar.value>=0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
