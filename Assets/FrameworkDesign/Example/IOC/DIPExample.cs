#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：DIP
 * 
 * Dependence Inversion Principle 依赖倒置
 * 
 * 创建时间：
 */

namespace FrameworkDesign.DIPExample
{
    public class DIPExample : MonoBehaviour
    {
        private void Start()
        {
            var container = new IOCContainer();
            container.Register<IStorage>(new PlayerPrefsStorage());
            var storage = container.Get<IStorage>();
            storage.SaveString("name", "运行时存储");
            Debug.Log(storage.LoadString("name"));

            // 切换实现
            container.Register<IStorage>(new EditorPrefsStorage());
            storage= container.Get<IStorage>();
            Debug.Log(storage.LoadString("name"));
        }
    }

    // 比如做存储
    public interface IStorage
    {
        void SaveString(string key, string value);
        string LoadString(string key, string defaultValue = "");
    }

    // 运行时的存储
    public class PlayerPrefsStorage : IStorage
    {
        public string LoadString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        public void SaveString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }
    }

    // 编辑器版本的存储
    public class EditorPrefsStorage : IStorage
    {
        public string LoadString(string key, string defaultValue = "")
        {
#if UNITY_EDITOR
            return EditorPrefs.GetString(key, defaultValue);
#else
            return 0;
#endif
        }

        public void SaveString(string key, string value)
        {
#if UNITY_EDITOR
            EditorPrefs.SetString(key, value);
#endif
        }
    }
}