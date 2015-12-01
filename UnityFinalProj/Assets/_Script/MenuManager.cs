using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public GameObject menu;
	public Menu CurrentMenu;
    
	void Start(){
        menu = GameObject.Find("MainMenu");
        CurrentMenu = menu.GetComponent<Menu>();
        CurrentMenu.GetComponent<Animator>().SetBool("IsOpen", true); ;
        CurrentMenu.GetComponent<CanvasGroup>().blocksRaycasts = CurrentMenu.GetComponent<CanvasGroup>().interactable = true; ;
		Debug.Log("start");
        
		ShowMenu (CurrentMenu);
	}

	public void ShowMenu(Menu menu){
		if (CurrentMenu != null)
			CurrentMenu.IsOpen = false;

		CurrentMenu = menu;
		CurrentMenu.IsOpen = true;
	
	}
    
	public void LoadGame(){
        //menu = GameObject.Find("MainMenu");
        Application.LoadLevel (1);
	}
    public void Exit()
    {
        Application.Quit();
    }
}
