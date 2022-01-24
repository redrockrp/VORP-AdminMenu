using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using vorpadminmenu_cl.Functions.Boosters;
using vorpadminmenu_cl.Menus;

namespace vorpadminmenu_cl.Actions
{
	public class NoClipAction : BaseScript
	{
		public NoClipAction()
		{
            Tick += NoClipAction_Tick;
		}

        [Tick]
        private async Task NoClipAction_Tick()
        {
            if (GetUserInfo.userGroup == "user")
            {
                return;
            }

            List<object> list = new List<object>();
            //ALT + G
            if (API.IsControlPressed(0, 0x8AAA0AD4) && API.IsControlJustPressed(0, 0x760A9C6F))
            {
                bool nc = Boosters.Getmclip();
                Boosters.Setmclip(!nc);
                BoosterFunctions.Noclip2(list);
            }
        }
    }
}

