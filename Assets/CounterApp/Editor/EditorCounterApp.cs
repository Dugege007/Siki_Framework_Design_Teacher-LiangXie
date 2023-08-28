using QFramework;
using UnityEditor;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：Unity编辑器扩展 EditorCounterApp
 * 
 * 在使用 Command 将 交互逻辑 与 表现逻辑 分离后，可以更加灵活的使用 Model 模块，提高底层代码的复用率
 * 比如此 Unity编辑器扩展
 * 使用 Command 还可以提高代码可读性和维护性，比如别人一看到 new AddCountCommand().Execute(); 这句代码就知道是干嘛的了
 * 
 * 创建时间：
 */

namespace CounterApp.Editor
{
    public class EditorCounterApp : EditorWindow, IController
    {
        [MenuItem("EditorConterApp/Open")]
        static void Open()
        {
            // 注册后打个补丁
            CounterApp.OnRegisterPatch += app => 
            { 
                app.RegisterUtility<IStorage>(new EditorPrefsStorage());
            };

            var window = GetWindow<EditorCounterApp>();
            window.position = new Rect(100, 100, 400, 300);
            window.titleContent = new GUIContent(nameof(EditorCounterApp));
            window.Show();
        }

        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                this.SendCommand<AddCountCommand>();
            }

            // 由于是实时渲染的，所以这里直接这样写
            GUILayout.Label(this.GetModel<ICounterModel>().Count.Value.ToString());

            if (GUILayout.Button("-"))
            {
                this.SendCommand<SubCountCommand>();
            }
        }
    }
}
