﻿using CitizenFX.Core;
using MenuAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vorpadminmenu_cl.Functions.Database;
using vorpadminmenu_cl.Functions.Utils;

namespace vorpadminmenu_cl.Menus
{
    class Database
    {
        private static Menu databaseMenu = new Menu(GetConfig.Langs["MenuDatabaseTitle"], GetConfig.Langs["MenuDatabaseDesc"]);
        private static bool setupDone = false;

        private static void SetupMenu()
        {
            if (setupDone) return;
            setupDone = true;
            MenuController.AddMenu(databaseMenu);

            databaseMenu.AddMenuItem(new MenuItem("AddMoney", "Press here to")
            {
                Enabled = true,
            });
            databaseMenu.AddMenuItem(new MenuItem("RemoveMoney", "Press here to")
            {
                Enabled = true,
            });
            databaseMenu.AddMenuItem(new MenuItem("AddXp", "Press here to ")
            {
                Enabled = true,
            });
            databaseMenu.AddMenuItem(new MenuItem("RemoveXp", "Press here ")
            {
                Enabled = true,
            });

            databaseMenu.OnItemSelect += async (_menu, _item, _index) =>
            {
                if (_index == 0)
                {
                    MainMenu.args = await UtilsFunctions.GetThreeByNUI(MainMenu.args, "Addmoney", "id", "Type:0-dollar,1-gold,2-rolpoints", "type", "Quantity", "quantity");
                    DatabaseFunctions.AddMoney(MainMenu.args);
                    MainMenu.args.Clear();
                }
                else if (_index == 1)
                {
                    MainMenu.args = await UtilsFunctions.GetThreeByNUI(MainMenu.args, "Addmoney", "id", "Type:0-dollar,1-gold,2-rolpoints", "type", "Quantity", "quantity");
                    DatabaseFunctions.RemoveMoney(MainMenu.args);
                    MainMenu.args.Clear();
                }
                if (_index == 2)
                {
                    MainMenu.args = await UtilsFunctions.GetTwoByNUI(MainMenu.args, "AddXp", "id", "Quantity", "quantity");
                    DatabaseFunctions.AddXp(MainMenu.args);
                    MainMenu.args.Clear();
                }
                else if (_index == 3)
                {
                    MainMenu.args = await UtilsFunctions.GetTwoByNUI(MainMenu.args, "AddXp", "id", "Quantity", "quantity");
                    DatabaseFunctions.RemoveXp(MainMenu.args);
                    MainMenu.args.Clear();
                }
            };
        }
        public static Menu GetMenu()
        {
            SetupMenu();
            return databaseMenu;
        }
    }
}
