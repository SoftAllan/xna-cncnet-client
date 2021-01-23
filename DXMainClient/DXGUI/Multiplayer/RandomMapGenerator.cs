using ClientGUI;
using DTAClient.Domain.Multiplayer;
using Microsoft.Xna.Framework;
using Rampastring.Tools;
using Rampastring.XNAUI;
using Rampastring.XNAUI.XNAControls;
using System;
using System.Collections.Generic;

namespace DTAClient.DXGUI.Multiplayer
{
    public class RandomMapGenerator : XNAWindow
    {
        public RandomMapGenerator(WindowManager windowManager, IniFile gameOptionsIni) : base(windowManager)
        {
            GameOptionsIni = gameOptionsIni;
        }

        public delegate void UseMapHandler();
        public event UseMapHandler UseMapClicked;

        protected XNAPanel MapOptionsPanel;
        protected GameLobby.MapPreviewBox MapPreviewPanel;

        protected XNAClientButton btnUseMap;
        protected XNAClientButton btnGenerateMap;
        protected XNAClientButton btnCancel;

        private IniFile GameOptionsIni;
        
        private const int ButtonWidth = 110;

        public override void Initialize()
        {
            
            Name = "RandomMapGenerator";
            ClientRectangle = new Rectangle(0, 0, 1100, 500);
            BackgroundTexture = AssetLoader.LoadTexture("optionsbg.png");

            MapOptionsPanel = new XNAPanel(WindowManager);
            MapOptionsPanel.Name = "MapOptionsPanel";
            MapOptionsPanel.ClientRectangle = new Rectangle(20, 20, 350, Height - 70);
            MapOptionsPanel.BackgroundTexture = AssetLoader.CreateTexture(new Color(0, 0, 0, 128), 1, 1);
            MapOptionsPanel.PanelBackgroundDrawMode = PanelBackgroundImageDrawMode.STRETCHED;

            // Todo: Right click on location gives an exception.
            MapPreviewPanel = new GameLobby.MapPreviewBox(WindowManager, new List<PlayerInfo>(), new List<PlayerInfo>(), new List<MultiplayerColor>(), new string[] { }, GameOptionsIni);
            MapPreviewPanel.Name = "MapPreviewPanel";
            MapPreviewPanel.ClientRectangle = new Rectangle(MapOptionsPanel.Right + 20, MapOptionsPanel.Y, Width - (MapOptionsPanel.Right + 40), MapOptionsPanel.Height);
            MapPreviewPanel.BackgroundTexture = AssetLoader.CreateTexture(new Color(0, 0, 0, 128), 1, 1);
            MapPreviewPanel.PanelBackgroundDrawMode = PanelBackgroundImageDrawMode.STRETCHED;
            
            btnGenerateMap = new XNAClientButton(WindowManager);
            btnGenerateMap.Name = "btnGenerateMap";
            btnGenerateMap.ClientRectangle = new Rectangle(MapOptionsPanel.X, Height - 35, ButtonWidth, 23);
            btnGenerateMap.Text = "Generate Map";
            btnGenerateMap.LeftClick += BtnGenerateMap_LeftClick;

            btnUseMap = new XNAClientButton(WindowManager);
            btnUseMap.Name = "btnUseMap";
            btnUseMap.ClientRectangle = new Rectangle(btnGenerateMap.Right + 12, Height - 35, ButtonWidth, 23);
            btnUseMap.Text = "Use Map";
            btnUseMap.LeftClick += BtnUseMap_LeftClick;

            btnCancel = new XNAClientButton(WindowManager);
            btnCancel.Name = "btnCancel";
            btnCancel.ClientRectangle = new Rectangle(MapPreviewPanel.Right - ButtonWidth, Height - 35, ButtonWidth, 23);
            btnCancel.Text = "Cancel";
            btnCancel.LeftClick += BtnCancel_LeftClick;

            AddChild(MapOptionsPanel);
            AddChild(MapPreviewPanel);
            AddChild(btnUseMap);
            AddChild(btnGenerateMap);
            AddChild(btnCancel);

            base.Initialize();

            WindowManager.CenterControlOnScreen(this);
        }

        private void BtnGenerateMap_LeftClick(object sender, EventArgs e)
        {
            GenerateMap();
            btnUseMap.Enable();
        }

        private void BtnUseMap_LeftClick(object sender, EventArgs e)
        {
            Hide();
            UseMapClicked?.Invoke();
        }

        private void BtnCancel_LeftClick(object sender, EventArgs e)
        {
            Hide();
        }

        public void Show()
        {
            DarkeningPanel.AddAndInitializeWithControl(WindowManager, this);
            Enable();
            btnUseMap.Visible = true;
            btnUseMap.Enabled = false;
        }

        private void Hide()
        {
            var parent = (DarkeningPanel)this.Parent;
            parent.RemoveChild(this);
            parent.Hide();
            parent.Hidden += Parent_Hidden;
            Disable();
        }

        private static void Parent_Hidden(object sender, EventArgs e)
        {
            var darkeningPanel = (DarkeningPanel)sender;
            darkeningPanel.WindowManager.RemoveControl(darkeningPanel);
            darkeningPanel.Hidden -= Parent_Hidden;
        }
        
        private void GenerateMap()
        {
            var mapName = "testramap";
            var mapLoader = new MapLoader();
            var testMap = mapLoader.LoadCustomMap($"Maps/Custom/{mapName}", out string resultMessage);
            MapPreviewPanel.Map = testMap;
        }

    }
}
