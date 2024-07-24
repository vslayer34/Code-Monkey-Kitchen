using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the play button")]
    private Button _playBtn;

    [SerializeField, Tooltip("Reference to the quit button")]
    private Button _quitBtn;



    //---------------------------------------------------------------------------------------------

    private void Start()
    {
        _playBtn.onClick.AddListener(() =>
        {
            Loader.LoadScene(SceneReference.GAME_PLAY);
        });


        _quitBtn.onClick.AddListener(() =>
        {
            #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
            #endif
            Application.Quit();
        });
    }
}
