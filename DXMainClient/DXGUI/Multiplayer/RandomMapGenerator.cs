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

        protected XNAClientButton btnMainMenu;



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
            base.Initialize();

            MapOptionsPanel = new XNAPanel(WindowManager);
            MapOptionsPanel.Name = "MapOptionsPanel";
            MapOptionsPanel.ClientRectangle = new Rectangle(10, 10, 300, 200);
            MapOptionsPanel.BackgroundTexture = AssetLoader.CreateTexture(new Color(0, 0, 0, 192), 1, 1);
            MapOptionsPanel.PanelBackgroundDrawMode = PanelBackgroundImageDrawMode.STRETCHED;

            btnMainMenu.Text = "Back"

            AddChild(MapOptionsPanel);

            PostInitialize();
        }

        /// <summary>
        /// Performs initialization that is necessary after derived 
        /// classes have performed their own initialization.
        /// </summary>
        protected void PostInitialize()
        {
            // InitializeWindow();
            // CenterOnParent();
            // WindowManager.CenterControlOnScreen(this);
        }

    }
}
