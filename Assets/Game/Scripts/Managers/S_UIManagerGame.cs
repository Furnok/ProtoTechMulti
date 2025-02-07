using UnityEngine;
using UnityEngine.SceneManagement;

public class S_UIManagerGame : MonoBehaviour
{
	//[Header("Parameters")]

	//[Header("References")]

	//[Header("RSE")]

	[SerializeField] private SceneName SceneName;

	private void Start()
	{
		SceneManager.LoadScene(SceneName.ToString());
	}
}