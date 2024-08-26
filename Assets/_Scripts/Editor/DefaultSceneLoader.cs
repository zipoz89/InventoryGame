#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

//This scripts always loads scene at index 0 on playmode 
[InitializeOnLoadAttribute]
public static class DefaultSceneLoader
{
    static DefaultSceneLoader(){
        EditorApplication.playModeStateChanged += LoadDefaultScene;
    }

    static void LoadDefaultScene(PlayModeStateChange state){
        if (state == PlayModeStateChange.ExitingEditMode) {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo ();
        }

        if (state == PlayModeStateChange.EnteredPlayMode) {
            EditorSceneManager.LoadScene (0);
        }
    }
}
#endif