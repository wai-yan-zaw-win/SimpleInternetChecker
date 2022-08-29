using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace HarioGames.SimpleInternetChecker
{
    /// <summary>
    /// Check whether the device is connected to the internet or not
    /// </summary>
    /// Developed by Wai Yan Zaw Win
    /// Email : waiyanzawwinstar8@gmail.com
    /// LinkedIn : https://www.linkedin.com/in/wai-yan-zaw-win/
    /// GitHub : https://github.com/wai-yan-zaw-win/
    public class SimpleInternetChecker : MonoBehaviour
    {
        [SerializeField] Text connectionStatusText;

        [SerializeField] GameObject connectionProblemUI;

        public bool isInternetOn, hasInternetConnection;

        public static SimpleInternetChecker Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating(nameof(CheckInternetConnection), 0, 5);
        }

        /// <summary>
        /// Check if the internet is connected or not
        /// </summary>
        public void CheckInternetConnection()
        {
            isInternetOn = false;
            hasInternetConnection = false;

            if (Application.internetReachability == NetworkReachability.NotReachable) //to check if the user turned wifi or mobile network on
            {
                isInternetOn = false;
            }
            else
            {
                isInternetOn = true;
            }

            if (isInternetOn)
            {
                StartCoroutine(CheckInternet());
            }
            else
            {
                hasInternetConnection = false;
                connectionStatusText.text = "Connecting...";
                connectionProblemUI.SetActive(true);
            }
        }

        /// <summary>
        /// Check if there is internet connection by sending webrequest to google
        /// </summary>
        /// <returns></returns>
        IEnumerator CheckInternet()
        {
            DateTime startTime = DateTime.Now;
            string link;
            
            //to solve some certificate issues
            if(Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                link = "https://www.google.com/";
            }
            else
            {
                link = "http://www.google.com/";
            }

            using (UnityWebRequest uwr = UnityWebRequest.Get(link))
            {
                AsyncOperation asyncOperation = uwr.SendWebRequest();

                while (!uwr.isDone)
                {
                    if (DateTime.Now.Subtract(startTime).TotalSeconds > 30)
                    {
                        Debug.LogWarning("TimeOut");
                        connectionStatusText.text = "Connecting...";
                        connectionProblemUI.SetActive(true);
                        CancelInvoke(nameof(CheckInternetConnection));
                        InvokeRepeating(nameof(CheckInternetConnection), 0, 5);
                        yield break;
                    }

                    yield return new WaitForSeconds(0.5f);
                }

                if (uwr.error != null)
                {
                    Debug.LogError(uwr.error);

                    hasInternetConnection = false;
                    connectionStatusText.text = "Connecting...";
                    connectionProblemUI.SetActive(true);
                    CancelInvoke(nameof(CheckInternetConnection));
                    InvokeRepeating(nameof(CheckInternetConnection), 0, 5);
                }
                else
                {
                    isInternetOn = true;
                    hasInternetConnection = true;

                    connectionStatusText.text = "Connecting...";
                    connectionProblemUI.SetActive(false);
                }
            }
        }
    }
}
