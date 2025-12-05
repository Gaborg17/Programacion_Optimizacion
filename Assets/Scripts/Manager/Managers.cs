using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Managers : MonoBehaviour
//PlayFab Manager
{
    [Header("Login")]
    [SerializeField] private TMP_InputField LoginEmail;
    [SerializeField] private TMP_InputField loginPassword;
    [SerializeField] private UnityEvent onLoginSuccess;


    [Header("Create Account")]
    [SerializeField] private TMP_InputField Ca_Username;
    [SerializeField] private TMP_InputField Ca_Email;
    [SerializeField] private TMP_InputField Ca_Password;
    [SerializeField] private TMP_InputField Ca_ConfirmedPassword;
    [SerializeField] private TMP_InputField Ca_AvatarUrl;
    [SerializeField] private UnityEvent onCreateAccountSuccess;

    [Header("UI")]
    [SerializeField] private Image ppf;
    [SerializeField] private TMP_Text playerDisplayName;
    [SerializeField] private TMP_Text highScore;

    private string userPlayFabId;

    void Start()
    {
        if (PlayFabSettings.DeveloperSecretKey == null)
        {
            PlayFabSettings.DeveloperSecretKey = "Y5IW8KNPS8GYBWZSA1HDWR3TZRTK8A7PCIXF7HAA5GQQJHIU44";
        }

        if (PlayFabSettings.TitleId == null)
        {
            PlayFabSettings.TitleId = "1DA25";
        }
    }

    public void CreateAccount()
    {


        if (Ca_Password.text != Ca_ConfirmedPassword.text)
        {
            Debug.Log("Password is different");
        }

        else
        {
            RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
            {
                Email = Ca_Email.text,
                Username = Ca_Username.text.ToLower(),
                DisplayName = Ca_Username.text,
                Password = Ca_Password.text,
                RequireBothUsernameAndEmail = true
            };

            PlayFabClientAPI.RegisterPlayFabUser(request, OnCreateAccountSuccess, OnCreateAccountError);

        }

       
    }

    

    public void OnCreateAccountSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("");
        userPlayFabId = result.PlayFabId;
        onCreateAccountSuccess?.Invoke();
    }

    public void OnCreateAccountError(PlayFabError error)
    {
        Debug.LogError(error);
    }

    public void SetUserAvatar()
    {
        UpdateAvatarUrlRequest request = new UpdateAvatarUrlRequest
        {
            ImageUrl = Ca_AvatarUrl.text,
        };

        PlayFabClientAPI.UpdateAvatarUrl(request, OnUserAvatarRequestSuccess,OnCreateAccountError);
    }

    public void OnUserAvatarRequestSuccess(EmptyResponse emptyResponse)
    {
        Debug.Log("Avatar asignado");
        SetPPFCanvas(Ca_AvatarUrl.text);
    }

    public void GetPLayerProfile()
    {
        GetPlayerProfileRequest request = new GetPlayerProfileRequest
        {
            PlayFabId = userPlayFabId,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowAvatarUrl = true,
                ShowDisplayName = true,
            }
        };

        PlayFabClientAPI.GetPlayerProfile(request, OnAvatarSuccess, OnCreateAccountError);
    }

    private void OnAvatarSuccess(GetPlayerProfileResult result)
    {
        playerDisplayName.text = result.PlayerProfile.DisplayName;
        Debug.Log(result);
        SetPPFCanvas(result.PlayerProfile.AvatarUrl);
    }


    public void LogInAccount()
    {
        LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest
        {
            Email = LoginEmail.text,
            Password = loginPassword.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress(request,OnLogInSuccess,OnLoginError);
    }


    public void OnLogInSuccess(LoginResult result)
    {
        Debug.Log("Inicio de sesion exitoso");
        userPlayFabId = result.PlayFabId;
        onLoginSuccess?.Invoke();
    }

    public void OnLoginError(PlayFabError error)
    {
        Debug.Log(error);
    }




    public int score;
    [ContextMenu("UpdateScore")]

    public void UpdateScore()
    {
        UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>()
            {
                new StatisticUpdate
                {
                    StatisticName = "SCORE",
                    Value = score,
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnPlayerStatsUpdate, OnLoginError);
    }


    public void GetLeaderBoard()
    {
        GetLeaderboardRequest request = new GetLeaderboardRequest
        {
            StatisticName = "SCORE",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderBoardSuccess, OnCreateAccountError);

    }

    public void OnGetLeaderBoardSuccess(GetLeaderboardResult rersult)
    {

    }


   public void OnPlayerStatsUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Score Actualizado Correctamente");
    }


    public void SetPPFCanvas(string url)
    {
        Debug.Log($"Set PPFCanvas ({url})");
        StartCoroutine(DownloadImage(url));
        
    }

    public IEnumerator DownloadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Texture2D t = DownloadHandlerTexture.GetContent(request);
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), Vector2.zero, 1f);
            ppf.sprite = s;
        }
    }


}
