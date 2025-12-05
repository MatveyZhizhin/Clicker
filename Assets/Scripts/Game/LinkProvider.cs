using UnityEngine;

namespace Assets.Scripts.Game
{
    public class LinkProvider : MonoBehaviour
    {
        public void FollowLink(string link)
        {
            Application.OpenURL(link);
        }
    }
}
