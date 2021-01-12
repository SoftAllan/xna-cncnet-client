using ClientGUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rampastring.Tools;
using Rampastring.XNAUI;
using Rampastring.XNAUI.XNAControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTAClient.DXGUI.Multiplayer
{
    // todo: Disable Top menu buttons not including Options.
    // todo: Restore Top menu buttons enable/disabled state when the dialog is closed.
    public class RandomMapGenerator : XNAWindow
    {
        public RandomMapGenerator(WindowManager windowManager) : base(windowManager)
        {
        }

        public delegate void UseMapHandler();
        public event UseMapHandler UseMapClicked;

        protected XNAPanel MapOptionsPanel;
        protected XNAPanel MapPreviewPanel;

        protected XNAClientButton btnUseMap;
        protected XNAClientButton btnCancel;

        private const int ButtonWidth = 92;

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

            MapPreviewPanel = new XNAPanel(WindowManager);
            MapPreviewPanel.Name = "MapPreviewPanel";
            MapPreviewPanel.ClientRectangle = new Rectangle(MapOptionsPanel.Right + 20, MapOptionsPanel.Y, Width - (MapOptionsPanel.Right + 40), MapOptionsPanel.Height);
            MapPreviewPanel.BackgroundTexture = AssetLoader.CreateTexture(new Color(0, 0, 0, 128), 1, 1);
            MapPreviewPanel.PanelBackgroundDrawMode = PanelBackgroundImageDrawMode.STRETCHED;

            btnUseMap = new XNAClientButton(WindowManager);
            btnUseMap.Name = "btnUseMap";
            btnUseMap.ClientRectangle = new Rectangle(104, Height - 35, ButtonWidth, 23);
            btnUseMap.Text = "Use Map";
            btnUseMap.LeftClick += BtnUseMap_LeftClick;

            btnCancel = new XNAClientButton(WindowManager);
            btnCancel.Name = "btnCancel";
            btnCancel.ClientRectangle = new Rectangle(Width - (104 + ButtonWidth), Height - 35, ButtonWidth, 23);
            btnCancel.Text = "Cancel";
            btnCancel.LeftClick += BtnCancel_LeftClick;

            AddChild(MapOptionsPanel);
            AddChild(MapPreviewPanel);
            AddChild(btnUseMap);
            AddChild(btnCancel);

            base.Initialize();

            WindowManager.CenterControlOnScreen(this);
        }

        private void BtnUseMap_LeftClick(object sender, EventArgs e)
        {
            Disable();
            UseMapClicked?.Invoke();
        }

        private void BtnCancel_LeftClick(object sender, EventArgs e)
        {
            Disable();
        }

    }
}
