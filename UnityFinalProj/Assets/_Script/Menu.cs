using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		_animator = GetComponent<Animator> ();
		_canvasGroup = GetComponent<CanvasGroup> ();

		var rect = GetComponent<RectTransform> ();
		rect.offsetMax = rect.offsetMin = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	public void Update () {
        
		_animator.SetBool ("IsOpen", IsOpen);
		IsOpen = _animator.GetBool ("IsOpen");
        //GetComponent<CanvasGroup>().alpha = 1f; _canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
		if (!IsOpen){//!_animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
            //Debug.Log("false:"+IsOpen);
           // _canvasGroup.alpha = 0f;
		} else {
			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
            Debug.Log(GetComponent<CanvasGroup>().alpha);
            //_canvasGroup.alpha = 1f;
            
		}
       
	}
	private Animator _animator;
	private CanvasGroup _canvasGroup;

	public bool IsOpen;

}
