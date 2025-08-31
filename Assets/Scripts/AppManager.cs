using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AppManager : MonoBehaviour
{
    public AppSO app;
    public GameObject appPage;
    public GameObject mainPage;
    public event Action<AppSO> OnChanged;
    public Animator animator;


    public void RedirectToAppPage()
    {
        animator.Rebind();
        StartCoroutine(PlayAnimAndHidePage(mainPage, "SlideIn"));
        RaiseChanged();
    }

    public void RedirectToMainPage()
    {
        animator.Rebind();
        StartCoroutine(PlayAnimAndHidePage(appPage, "SlideOut"));
    }

    private IEnumerator PlayAnimAndHidePage(GameObject page, string animName)
    {
        animator.SetTrigger(animName);

  
        yield return new WaitUntil(() =>
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        page.SetActive(false);
    }


    public void RaiseChanged()
    {
        OnChanged?.Invoke(app);
        Debug.Log($"Sended + {app}");
    }
}
