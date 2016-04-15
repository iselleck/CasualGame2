using UnityEngine;
//using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public class StartButton : MonoBehaviour
{

    public Sprite standardSprite;
    private UnityEngine.UI.Button button;

	// Use this for initialization
	void Start ()
    {
        standardSprite = (Sprite)Resources.Load("start_base.png");

        button = GetComponent<UnityEngine.UI.Button>();
        button.image.overrideSprite = standardSprite;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

	public void onClick(){
		//SceneManager.LoadScene (1, LoadSceneMode.Single);
	}
}
