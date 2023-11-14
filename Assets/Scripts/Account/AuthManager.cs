using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using System.Threading.Tasks;
using System;

public class AuthManager
{
    //싱글톤
    private static AuthManager _instance;
    public static AuthManager instance
    {
        get
        {
            if (_instance == null) _instance = new AuthManager();
            return _instance;
        }
    }

    private FirebaseAuth auth; //로그인 & 회원가입 등에 사용
    private FirebaseUser user; //인증 완료된 유저 정보

    private AuthManager()
    {
        auth = FirebaseAuth.DefaultInstance;

        auth.StateChanged += (object sender, EventArgs e) =>
        {
            if (auth.CurrentUser != null) Debug.Log(auth.CurrentUser.Email);
            else Debug.Log("x");

            //계정 상태가 바뀔 때마다 호출
            if (auth.CurrentUser != user) //CurrentUser =  
            {
                bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
                if (!signed && user != null)
                {
                    Debug.Log("로그아웃");
                }

                user = auth.CurrentUser;
                if (signed)
                {

                }
            }

        };
    }

    //

    public void CreateAccount(string email, string password) //회원가입
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("회원가입 실패");
                return;
            }
            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;
            Debug.Log("회원가입 완료");
        });

    }

    public void Login(string email, string password)  //로그인
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("로그인 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("로그인 실패");
                return;
            }
            AuthResult authResult = task.Result;
            user = authResult.User;
            Debug.Log("로그인 완료");
        });

    }

    public void LogOut()
    {
        auth.SignOut();
    }


    public bool CheckLogin()
    {
        return auth.CurrentUser != null;
    }
}
