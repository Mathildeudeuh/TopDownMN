using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] public GameObject screen;
    [SerializeField] public string sceneToLoad;

    public void LoadSceneAsync()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        // Instance de l'objet � charger
        var instance = Instantiate(screen);

        // Ne pas d�truire l'objet pendant le chargement
        DontDestroyOnLoad(screen);

        // S�ne � charger
        var loading = SceneManager.LoadSceneAsync(sceneToLoad);

        // Refuser l'activation
        loading.allowSceneActivation = false;

        // On v�rifie si le chergement est termin�
        while (loading.isDone == false)
        {
            // Si le chargement atteint 100%
            if(loading.progress >= 0.9f)
            {
                // La sc�ne se lance
                loading.allowSceneActivation = true;
                // L'�cran de chargement se d�truit
                Destroy(screen);
            }

            yield return new WaitForSeconds(2);

        }
    }
}
