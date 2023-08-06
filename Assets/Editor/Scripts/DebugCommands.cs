using UnityEditor;
using UnityEngine;

public class DebugCommands : EditorWindow
{
    private void OnGUI()
    {
        if (!Application.isPlaying)
        {
            GUILayout.Label("No commands available. Press Play to load more.");
            return;
        }

        var player = GameObject.FindWithTag("Player");
        var snakePartManager = player.GetComponent<SnakePartManager>();

        if (snakePartManager) SnakeCommands(snakePartManager);
    }

    [MenuItem("Window/Debug Commands")]
    public static void ShowWindow()
    {
        GetWindow<DebugCommands>("Debug Commands");
    }

    private static void SnakeCommands(SnakePartManager snake)
    {
        if (GUILayout.Button("Grow")) snake.Grow();

        if (GUILayout.Button("Grow x10"))
            for (var i = 0; i < 10; i++)
                snake.Grow();
    }
}