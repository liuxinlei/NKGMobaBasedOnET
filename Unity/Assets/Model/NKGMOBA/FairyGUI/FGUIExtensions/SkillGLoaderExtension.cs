//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年6月29日 18:21:36
//------------------------------------------------------------

using FairyGUI;
using UnityEngine;

namespace ETModel
{
    public class SkillGLoaderExtension: GLoader
    {
        protected override void LoadExternal()
        {
            StartToLoadIcon().Coroutine();
        }

        private async ETVoid StartToLoadIcon()
        {
            GameObject HeroAvatars = Game.Scene.GetComponent<ResourcesComponent>().LoadAsset<GameObject>(ABPathUtilities.GetTexturePath("HeroAvarars"));
            Texture2D tex = HeroAvatars.GetTargetObjectFromRC<Sprite>("Darius").texture;
            if (tex != null)
                onExternalLoadSuccess(new NTexture(tex));
            else
                onExternalLoadFailed();
        }
    }
}