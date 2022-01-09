using UnityEditor;
using System.Reflection;
using System;

public class DisplayManager
{
    public static void SwitchGameViewDisplay(int targetDisplay)
    {
        //GameViewのディスプレイは8枚まで
        if (targetDisplay < 0 || 7 < targetDisplay)
            return;
        string assemblyName = "UnityEditor.dll";
        Assembly assembly = Assembly.Load(assemblyName);
#if UNITY_2019_1_OR_NEWER
        Type gameView = assembly.GetType("UnityEditor.PlayModeView");
#else
        //Unity2018はGameViewクラスにm_TargetDisplayが定義されていた。
        Type gameView = assembly.GetType("UnityEditor.GameView");
#endif
        EditorWindow editorWindow = EditorWindow.GetWindow(gameView);
        FieldInfo field = gameView.GetField("m_TargetDisplay", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(editorWindow, targetDisplay);
    }

    //-----------------------------------------------------------------------------------------------
    //メニューバーでディスプレイを切り替えられるように設定
    //-----------------------------------------------------------------------------------------------

    [MenuItem("MyTools/TargetDisplay1")]
    static void SwitchGameViewTargetDisplay1()
    {
        DisplayManager.SwitchGameViewDisplay(0);
    }
    [MenuItem("MyTools/TargetDisplay2")]
    static void SwitchGameViewTargetDisplay2()
    {
        DisplayManager.SwitchGameViewDisplay(1);
    }
    [MenuItem("MyTools/TargetDisplay3")]
    static void SwitchGameViewTargetDisplay3()
    {
        DisplayManager.SwitchGameViewDisplay(2);
    }
    [MenuItem("MyTools/TargetDisplay4")]
    static void SwitchGameViewTargetDisplay4()
    {
        DisplayManager.SwitchGameViewDisplay(3);
    }
    [MenuItem("MyTools/TargetDisplay5")]
    static void SwitchGameViewTargetDisplay5()
    {
        DisplayManager.SwitchGameViewDisplay(4);
    }
    [MenuItem("MyTools/TargetDisplay6")]
    static void SwitchGameViewTargetDisplay6()
    {
        DisplayManager.SwitchGameViewDisplay(5);
    }
    [MenuItem("MyTools/TargetDisplay7")]
    static void SwitchGameViewTargetDisplay7()
    {
        DisplayManager.SwitchGameViewDisplay(6);
    }
    [MenuItem("MyTools/TargetDisplay8")]
    static void SwitchGameViewTargetDisplay8()
    {
        DisplayManager.SwitchGameViewDisplay(7);
    }
}
