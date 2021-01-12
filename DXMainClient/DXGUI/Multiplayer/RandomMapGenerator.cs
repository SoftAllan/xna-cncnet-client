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
    public class RandomMapGenerator : XNAWindow
    {
        public RandomMapGenerator(WindowManager windowManager) : base(windowManager)
        {


        }

        protected XNAPanel MapOptionsPanel;

        protected XNAClientButton btnCancel;



        #region Overrides
        protected override void OnUpdateOrderChanged(object sender, EventArgs args)
        {
            base.OnUpdateOrderChanged(sender, args);
        }

        protected override void OnEnabledChanged(object sender, EventArgs args)
        {
            base.OnEnabledChanged(sender, args);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void OnVisibleChanged(object sender, EventArgs args)
        {
            base.OnVisibleChanged(sender, args);
        }

        protected override void OnDrawOrderChanged(object sender, EventArgs args)
        {
            base.OnDrawOrderChanged(sender, args);
        }

        protected override void OnClientRectangleUpdated()
        {
            base.OnClientRectangleUpdated();
        }

        public override void OnMouseEnter()
        {
            base.OnMouseEnter();
        }

        public override void OnMouseLeave()
        {
            base.OnMouseLeave();
        }

        public override void OnMouseLeftDown()
        {
            base.OnMouseLeftDown();
        }

        public override void OnMouseRightDown()
        {
            base.OnMouseRightDown();
        }

        public override void OnLeftClick()
        {
            base.OnLeftClick();
        }

        public override void OnDoubleLeftClick()
        {
            base.OnDoubleLeftClick();
        }

        public override void OnRightClick()
        {
            base.OnRightClick();
        }

        public override void OnMouseMove()
        {
            base.OnMouseMove();
        }

        public override void OnMouseOnControl(MouseEventArgs eventArgs)
        {
            base.OnMouseOnControl(eventArgs);
        }

        public override void OnMouseScrolled()
        {
            base.OnMouseScrolled();
        }

        public override void OnSelectedChanged()
        {
            base.OnSelectedChanged();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        } 
        #endregion

        public override void Initialize()
        {
            
            Name = "RandomMapGenerator";
            ClientRectangle = new Rectangle(0, 0, 600, 600);
            BackgroundTexture = AssetLoader.LoadTexture("gamelobbybg.png");

            MapOptionsPanel = new XNAPanel(WindowManager);
            MapOptionsPanel.Name = "MapOptionsPanel";
            MapOptionsPanel.ClientRectangle = new Rectangle(10, 10, 550, 500);
            MapOptionsPanel.BackgroundTexture = AssetLoader.CreateTexture(new Color(0, 0, 0, 192), 1, 1);
            MapOptionsPanel.PanelBackgroundDrawMode = PanelBackgroundImageDrawMode.STRETCHED;

            btnCancel = new XNAClientButton(WindowManager);
            btnCancel.Name = "btnCancel";
            btnCancel.ClientRectangle = new Rectangle(Width - 104,
                Height - 35, 92, 23);
            btnCancel.Text = "Cancel";
            btnCancel.LeftClick += BtnCancel_LeftClick;

            AddChild(MapOptionsPanel);
            AddChild(btnCancel);

            base.Initialize();

            WindowManager.CenterControlOnScreen(this);
        }

        private void BtnCancel_LeftClick(object sender, EventArgs e)
        {
            Disable();
        }

    }
}
