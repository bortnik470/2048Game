using UnityEngine;
using System.Collections;

public class MenuControler : MonoBehaviour
{
    [SerializeField] private ActionController _actionController;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _GameUI;

    private IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(0.1f);
        PauseGame();
    }

    private void Start()
    {
        GetComponent<CreateNewCube>().CreateCube();
        StartCoroutine(LoadDelay());
    }

    public void StartGame()
    {
        _pauseMenu.SetActive(false);
        _GameUI.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        _GameUI.SetActive(false);
        Time.timeScale = 0;
    }
}
