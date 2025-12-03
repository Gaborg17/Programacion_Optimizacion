using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class Managers : MonoBehaviour
//PlayFab Manager
{
    [Header("Login")]
    [SerializeField] private TMP_InputField LoginEmail;
    [SerializeField] private TMP_InputField loginPassword;

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
        };

        PlayFabClientAPI.GetPlayerProfile(request, OnAvatarSuccess, OnCreateAccountError);
    }

    private void OnAvatarSuccess(GetPlayerProfileResult result)
    {
        playerDisplayName.text = result.PlayerProfile.DisplayName;
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
    }

    public void OnLoginError(PlayFabError error)
    {
        Debug.Log(error);
    }




    [ContextMenu("UpdateScore")]
    private void UpdateScore(int score)
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

   public void OnPlayerStatsUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Score Actualizado Correctamente");
    }


    public void SetPPFCanvas(string url)
    {

    }


}
