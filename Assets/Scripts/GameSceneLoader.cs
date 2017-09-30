using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class GameSceneLoader : MonoBehaviour {

	public string sceneName = "game";

    public Image hider;

    public Image preLoader;

	private Button thisBtn;

    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
    void Start()
	{
		thisBtn = this.GetComponent<Button> ();
        thisBtn.onClick.AddListener(OnClickListener);
	}

    private void OnClickListener () {

        hider.gameObject.SetActive(true);

        if (hider!= null)
        {
            hider.DOFade(255, 300);
        }

        if(preLoader!=null)
        {
            preLoader.gameObject.SetActive(true);
            preLoader.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, -1080), 2, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        }
        StartCoroutine("SceneLoad");
        //SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

}
