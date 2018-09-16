// This file is part of Mystery Dungeon eXtended.

// Copyright (C) 2015 Pikablu, MDX Contributors, PMU Staff

// Mystery Dungeon eXtended is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Mystery Dungeon eXtended is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Mystery Dungeon eXtended.  If not, see <http://www.gnu.org/licenses/>.


using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Widgets;

namespace Client.Logic.Windows.Editors
{
    class EditorManager
    {
        public static winAdminPanel AdminPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winAdminPanel");
                if (window != null)
                {
                    return (winAdminPanel)window;
                }
                else
                {
                    winAdminPanel adminPanel = new winAdminPanel();
                    return adminPanel;
                }
            }
        }


        public static winGuildPanel GuildPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winGuildPanel");
                if (window != null)
                {
                    return (winGuildPanel)window;
                }
                else
                {
                    winGuildPanel guildPanel = new winGuildPanel();
                    return guildPanel;
                }
            }
        }

        public static winItemPanel ItemPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winItemPanel");
                if (window != null)
                {
                    return (winItemPanel)window;
                }
                else
                {
                    winItemPanel itemPanel = new winItemPanel();

                    return itemPanel;
                }
            }
        }

        public static winMovePanel MovePanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winMovePanel");
                if (window != null)
                {
                    return (winMovePanel)window;
                }
                else
                {
                    winMovePanel movePanel = new winMovePanel();

                    return movePanel;
                }
            }
        }

        public static winArrowPanel ArrowPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winArrowPanel");
                if (window != null)
                {
                    return (winArrowPanel)window;
                }
                else
                {
                    winArrowPanel ArrowPanel = new winArrowPanel();
                    return ArrowPanel;
                }
            }
        }

        public static winEmotionPanel EmotionPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winEmotionPanel");
                if (window != null)
                {
                    return (winEmotionPanel)window;
                }
                else
                {
                    winEmotionPanel EmotionPanel = new winEmotionPanel();
                    return EmotionPanel;
                }
            }
        }


        public static winDungeonPanel DungeonPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winDungeonPanel");
                if (window != null)
                {
                    return (winDungeonPanel)window;
                }
                else
                {
                    winDungeonPanel DungeonPanel = new winDungeonPanel();
                    return DungeonPanel;
                }
            }
        }


        public static winNPCPanel NPCPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winNPCPanel");
                if (window != null)
                {
                    return (winNPCPanel)window;
                }
                else
                {
                    winNPCPanel NPCPanel = new winNPCPanel();
                    return NPCPanel;
                }
            }
        }

        public static winRDungeonPanel RDungeonPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winRDungeonPanel");
                if (window != null)
                {
                    return (winRDungeonPanel)window;
                }
                else
                {
                    winRDungeonPanel RDungeonPanel = new winRDungeonPanel();
                    return RDungeonPanel;
                }
            }
        }


        public static winMissionPanel MissionPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winMissionPanel");
                if (window != null)
                {
                    return (winMissionPanel)window;
                }
                else
                {
                    winMissionPanel MissionPanel = new winMissionPanel();
                    return MissionPanel;
                }
            }
        }

        public static winEvolutionPanel EvolutionPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winEvolutionPanel");
                if (window != null)
                {
                    return (winEvolutionPanel)window;
                }
                else
                {
                    winEvolutionPanel EvolutionPanel = new winEvolutionPanel();
                    return EvolutionPanel;
                }
            }
        }


        public static winShopPanel ShopPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winShopPanel");
                if (window != null)
                {
                    return (winShopPanel)window;
                }
                else
                {
                    winShopPanel ShopPanel = new winShopPanel();
                    return ShopPanel;
                }
            }
        }

        public static winStoryPanel StoryPanel
        {
            get
            {
                Window window = WindowManager.FindWindow("winStoryPanel");
                if (window != null)
                {
                    return (winStoryPanel)window;
                }
                else
                {
                    winStoryPanel StoryPanel = new winStoryPanel();
                    return StoryPanel;
                }
            }
        }

        public static Editors.ScriptEditor.frmScriptEditor ScriptEditor
        {
            get;
            set;
        }


        public static void OpenMapEditor()
        {
            WindowSwitcher.GameWindow.inMapEditor = true;
            Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayMapGrid = IO.Options.MapGrid;
            Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayAttributes = IO.Options.DisplayAttributes;
            Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayDungeonValues = IO.Options.DisplayDungeonValues;
            WindowSwitcher.GameWindow.EnableMapEditorWidgets(Enums.MapEditorLimitTypes.Full, true);
            WindowSwitcher.FindWindow("winExpKit").Visible = false;
        }


        public static void CloseMapEditor()
        {
            if (WindowSwitcher.GameWindow.inMapEditor)
            {
                WindowSwitcher.GameWindow.DisableMapEditorWidgets();
                WindowSwitcher.FindWindow("winExpKit").Visible = true;
                WindowSwitcher.GameWindow.inMapEditor = false;
                Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayMapGrid = false;
                Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayAttributes = false;
                Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayDungeonValues = false;
            }
        }

        public static void OpenHouseEditor()
        {
            WindowSwitcher.GameWindow.inMapEditor = true;
            Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayMapGrid = IO.Options.MapGrid;
            Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayAttributes = IO.Options.DisplayAttributes;
            Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayDungeonValues = IO.Options.DisplayDungeonValues;
            WindowSwitcher.GameWindow.EnableMapEditorWidgets(Enums.MapEditorLimitTypes.House, false);
            WindowSwitcher.FindWindow("winExpKit").Visible = false;
        }


        public static void CloseHouseEditor()
        {
            if (WindowSwitcher.GameWindow.inMapEditor)
            {
                WindowSwitcher.GameWindow.DisableMapEditorWidgets();
                WindowSwitcher.FindWindow("winExpKit").Visible = true;
                WindowSwitcher.GameWindow.inMapEditor = false;
                Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayMapGrid = false;
                Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayAttributes = false;
                Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.DisplayDungeonValues = false;
            }
        }

        public static void OpenItemList()
        {
        }

        // TODO: StoryEditor Opening and Closing (Editor Manager)
        //public static void OpenStoryEditor() {
        //WindowManager.AddWindow(new winStoryPanel());
        //}

        public static void CloseStoryEditor()
        {
            WindowManager.FindWindow("winStoryPanel").Close();
        }
    }
}
