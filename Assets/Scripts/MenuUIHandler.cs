using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private string sampleText = "Best Score : ";
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private TMP_InputField inputName;

    private void Start()
    {
        text.text = sampleText + BestScore.Instance.BestScoreResult;
        inputName.text = BestScore.Instance.BestPlayerName;
    }

    public void StartNewGame()
    {
        if (inputName.text != "")
        {
            SessionData.Instance.PlayerName = inputName.text;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
