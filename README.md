# Unity SimpleInternetChecker

This package contains simple drag and drop internet connection checker for Unity. It uses [UnityWebRequest](https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.html) to send and get [WebRequest](https://docs.microsoft.com/en-us/dotnet/api/system.net.webrequest?view=net-6.0) from [Google](google.com).

# How to Use

It is pretty simple actually. 
Just drag and drop SimpleInternetChecker Prefab from HarioGames/Examples/Prefabs/ .

<img src="https://imgur.com/gallery/FEYOjw9" alt="Prefab Image">

## Checking Conditions

You might need to call the following namespace to get SimpleInternetChecker Instance.
```c#
using HarioGames.SimpleInternetChecker;
```

Here is an example of checking and doing something if there is intenet connection.
```c#
void FixedUpdate()
{
    if(SimpleInternetChecker.Instance != null)
    {
        if(!SimpleInternetChecker.Instance.isInternetOn  && !SimpleInternetChecker.Instance.hasInternetConnection)
        {
            Debug.Log("No Internet");
            //Show no internet pop up or do something
        }
        else
        {
            if(!SimpleInternetChecker.Instance.hasInternetConnection)
            {
                Debug.Log("Checking internet connection");
            }
        }
    }
}
```




# Contacts : 

You can contact me via waiyanzawwinstar8@gmail.com.

## Social Medias :

[<img align="left" alt="Wai Yan Zaw Win | Facebook" width="28px" src="https://img.icons8.com/ios-glyphs/30/1778f2/facebook-new.png" />][facebook]
[<img align="left" alt="Wai Yan Zaw Win | Instagram" width="28px" src="https://img.icons8.com/material-outlined/24/aaaaaa/instagram-new--v1.png" />][instagram]
[<img align="left" alt="Wai Yan Zaw Win | LinkedIn" width="28px" src="https://img.icons8.com/fluent-systems-filled/50/0077b5/linkedin.png" />][linkedin]

<br />

[facebook]: https://www.facebook.com/WaiYanZawWin.Leo/
[instagram]: https://www.instagram.com/waiyanzawwin0_0/
[linkedin]: https://www.linkedin.com/in/wai-yan-zaw-win/
