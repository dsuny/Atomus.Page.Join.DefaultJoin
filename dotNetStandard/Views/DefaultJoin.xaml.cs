using Atomus.Page.Join.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atomus.Page.Join
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DefaultJoin : ContentPage, ICore
    {
        #region INIT
        public DefaultJoin()
        {
            this.BindingContext = new DefaultJoinViewModel(this);

            InitializeComponent();

            this.BackgroundColor = ((string)Config.Client.GetAttribute("BackgroundColor")).ToColor();
        }
        #endregion

        #region EVENT
        protected override void OnAppearing()
        {
        }

        private DisplayOrientation DisplayOrientation = DisplayOrientation.Unknown;
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called

            if (this.DisplayOrientation != DeviceDisplay.MainDisplayInfo.Orientation)
            {
                if (this.BindingContext != null)
                    (this.BindingContext as DefaultJoinViewModel).DeviceDirection = DeviceDisplay.MainDisplayInfo.Orientation;

                this.DisplayOrientation = DeviceDisplay.MainDisplayInfo.Orientation;
            }
        }
        #endregion

        #region ETC
        #endregion
    }
}