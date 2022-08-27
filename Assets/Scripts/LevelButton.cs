using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string sceneName;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(GoToTheLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToTheLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
