using Atomus.Page.Join.Controllers;
using Atomus.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Atomus.Page.Join.ViewModel
{
    public class DefaultJoinViewModel : MVVM.ViewModel
    {
        #region Declare
        private ICore core;

        private bool userAgreementIsToggled;
        private string userAgreement;
        private Color userAgreementBackgroundColor;
        private bool personalInformationCollectionAgreementToggled;
        private string personalInformationCollectionAgreement;
        private Color personalInformationCollectionAgreementColor;

        private bool newChecked;
        private bool passwordChangeChecked;

        private string email;
        private string reEmail;
        private string reEmailPlaceholder;
        private bool reEmailIsPassword;
        private Keyboard reEmailKeyboard;
        private string accessNumber;
        private string reAccessNumber;
        private string nickname;
        private bool activityIndicator;
        private bool isEnabledControl;

        private string backgroundImage;
        private Aspect backgroundImageAspect;

        private DisplayOrientation deviceDirection;
        #endregion

        #region Property
        public ICore Core
        {
            get
            {
                return this.core;
            }
            set
            {
                this.core = value;
            }
        }

        public bool UserAgreementIsToggled
        {
            get
            {
                return this.userAgreementIsToggled;
            }
            set
            {
                if (this.userAgreementIsToggled != value)
                {
                    this.userAgreementIsToggled = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string UserAgreement
        {
            get
            {
                return this.userAgreement;
            }
            set
            {
                if (this.userAgreement != value)
                {
                    this.userAgreement = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Color UserAgreementBackgroundColor
        {
            get
            {
                return this.userAgreementBackgroundColor;
            }
            set
            {
                if (this.userAgreementBackgroundColor != value)
                {
                    this.userAgreementBackgroundColor = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool PersonalInformationCollectionAgreementToggled
        {
            get
            {
                return this.personalInformationCollectionAgreementToggled;
            }
            set
            {
                if (this.personalInformationCollectionAgreementToggled != value)
                {
                    this.personalInformationCollectionAgreementToggled = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string PersonalInformationCollectionAgreement
        {
            get
            {
                return this.personalInformationCollectionAgreement;
            }
            set
            {
                if (this.personalInformationCollectionAgreement != value)
                {
                    this.personalInformationCollectionAgreement = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Color PersonalInformationCollectionAgreementBackgroundColor
        {
            get
            {
                return this.personalInformationCollectionAgreementColor;
            }
            set
            {
                if (this.personalInformationCollectionAgreementColor != value)
                {
                    this.personalInformationCollectionAgreementColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool NewChecked
        {
            get
            {
                return this.newChecked;
            }
            set
            {
                if (this.newChecked != value)
                {
                    this.newChecked = value;
                    NotifyPropertyChanged();

                    if (this.newChecked)
                    {
                        this.PasswordChangeChecked = false;
                        this.ReEmailPlaceholder = "Re Email";
                        this.ReEmailIsPassword = false;
                        this.ReEmailKeyboard = Keyboard.Email;
                    }
                    else
                        this.PasswordChangeChecked = true;

                    this.ReEmail = "";
                    this.AccessNumber = "";
                    this.ReAccessNumber = "";
                }
            }
        }
        public bool PasswordChangeChecked
        {
            get
            {
                return this.passwordChangeChecked;
            }
            set
            {
                if (this.passwordChangeChecked != value)
                {
                    this.passwordChangeChecked = value;
                    NotifyPropertyChanged();


                    if (this.passwordChangeChecked)
                    {
                        this.NewChecked = false;
                        this.ReEmailPlaceholder = "Old Password";
                        this.ReEmailIsPassword = true;
                        this.ReEmailKeyboard = Keyboard.Default;
                    }
                    else
                        this.NewChecked = true;
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string ReEmail
        {
            get
            {
                return this.reEmail;
            }
            set
            {
                if (this.reEmail != value)
                {
                    this.reEmail = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string ReEmailPlaceholder
        {
            get
            {
                return this.reEmailPlaceholder;
            }
            set
            {
                if (this.reEmailPlaceholder != value)
                {
                    this.reEmailPlaceholder = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool ReEmailIsPassword
        {
            get
            {
                return this.reEmailIsPassword;
            }
            set
            {
                if (this.reEmailIsPassword != value)
                {
                    this.reEmailIsPassword = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Keyboard ReEmailKeyboard
        {
            get
            {
                return this.reEmailKeyboard;
            }
            set
            {
                if (this.reEmailKeyboard != value)
                {
                    this.reEmailKeyboard = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string AccessNumber
        {
            get
            {
                return this.accessNumber;
            }
            set
            {
                if (this.accessNumber != value)
                {
                    this.accessNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string ReAccessNumber
        {
            get
            {
                return this.reAccessNumber;
            }
            set
            {
                if (this.reAccessNumber != value)
                {
                    this.reAccessNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Nickname
        {
            get
            {
                return this.nickname;
            }
            set
            {
                if (this.nickname != value)
                {
                    this.nickname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool ActivityIndicator
        {
            get
            {
                return this.activityIndicator;
            }
            set
            {
                if (this.activityIndicator != value)
                {
                    this.activityIndicator = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool IsEnabledControl
        {
            get
            {
                return this.isEnabledControl;
            }
            set
            {
                if (this.isEnabledControl != value)
                {
                    this.isEnabledControl = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string BackgroundImage
        {
            get
            {
                return this.backgroundImage;
            }
            set
            {
                if (this.backgroundImage != value)
                {
                    this.backgroundImage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Aspect BackgroundImageAspect
        {
            get
            {
                return this.backgroundImageAspect;
            }
            set
            {
                if (this.backgroundImageAspect != value)
                {
                    this.backgroundImageAspect = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DisplayOrientation DeviceDirection
        {
            get
            {
                return this.deviceDirection;
            }
            set
            {
                if (this.deviceDirection != value)
                {
                    this.deviceDirection = value;

                    if (this.deviceDirection == DisplayOrientation.Landscape)
                        this.BackgroundImage = this.core.GetAttribute("BackgroundImage.Horizontal");
                    else
                        this.BackgroundImage = this.core.GetAttribute("BackgroundImage.Vertical");

                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand JoinCommand { get; set; }
        public ICommand BackCommand { get; set; }
        #endregion

        #region INIT
        public DefaultJoinViewModel()
        {
        }
        public DefaultJoinViewModel(ICore core) : this()
        {
            this.Core = core;

            this.userAgreementIsToggled = false;
            this.userAgreement = this.core.GetAttribute("UserAgreement");
            this.userAgreementBackgroundColor = ((string)Config.Client.GetAttribute("BarBackgroundColor")).ToColor();
            this.personalInformationCollectionAgreementToggled = false;
            this.personalInformationCollectionAgreement = this.core.GetAttribute("PersonalInformationCollectionAgreement");
            this.personalInformationCollectionAgreementColor = ((string)Config.Client.GetAttribute("BarBackgroundColor")).ToColor();

            this.newChecked = true;
            this.passwordChangeChecked = false;

            this.email = "";
            this.reEmail = "";
            this.reEmailPlaceholder = "Re Email";
            this.reEmailIsPassword = true;
            this.reEmailKeyboard = Keyboard.Email;
            this.accessNumber = "";
            this.reAccessNumber = "";
            this.nickname = "";

            this.activityIndicator = false;
            this.isEnabledControl = true;
            this.backgroundImage = null;
            this.backgroundImageAspect = Aspect.AspectFit;

            this.JoinCommand = new Command(async () => await this.JoinProcess()
                                            , () => { return !this.ActivityIndicator; });

            this.BackCommand = new Command(async () => await this.BackProcess()
                                            , () => { return !this.ActivityIndicator; });

            this.deviceDirection = DisplayOrientation.Unknown;
        }
        #endregion

        #region IO
        private async Task JoinProcess()
        {
            Service.IResponse result;
            ISecureHashAlgorithm secureHashAlgorithm;

            try
            {
                this.IsEnabledControl = false;
                this.ActivityIndicator = true;
                (this.JoinCommand as Command).ChangeCanExecute();

                if (!this.UserAgreementIsToggled)
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "이용약관 동의를 해야 진행 가능 합니다.", "OK");
                    return;
                }

                if (!this.PersonalInformationCollectionAgreementToggled)
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "개인정보 수집 및 이용 동의를 해야 진행 가능 합니다.", "OK");
                    return;
                }

                if (this.Email.IsNullOrEmpty())
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "이메일을 입력해 주시기 바랍니다.", "OK");
                    return;
                }

                if (this.AccessNumber.IsNullOrEmpty())
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "비밀번호를 입력해 주시기 바랍니다.", "OK");
                    return;
                }

                if (this.AccessNumber != this.ReAccessNumber)
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "비밀번호가 일치하지 않습니다.", "OK");
                    return;
                }

                secureHashAlgorithm = (ISecureHashAlgorithm)this.core.CreateInstance("SecureHashAlgorithm");

                if (this.NewChecked)
                {
                    if (this.Email != this.ReEmail)
                    {
                        await Application.Current.MainPage.DisplayAlert("Warning", "이메일이 일치하지 않습니다.", "OK");
                        return;
                    }

                    if (this.Nickname.IsNullOrEmpty())
                    {
                        await Application.Current.MainPage.DisplayAlert("Warning", "닉네임을 입력해 주시기 바랍니다.", "OK");
                        return;
                    }

                    result = await this.core.SaveAsync(this.Email, secureHashAlgorithm.ComputeHashToBase64String(this.AccessNumber), this.Nickname);

                    if (result.Status == Service.Status.OK)
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "가입이 완료 되었습니다.", "OK");
                        await this.BackProcess();
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Warning", result.Message, "OK");
                }
                else
                {
                    if (this.ReEmail.IsNullOrEmpty())
                    {
                        await Application.Current.MainPage.DisplayAlert("Warning", "기존 비밀번호를 입력해 주시기 바랍니다.", "OK");
                        return;
                    }

                    result = await this.core.SavePasswordChangeAsync(this.Email, secureHashAlgorithm.ComputeHashToBase64String(this.ReEmail), secureHashAlgorithm.ComputeHashToBase64String(this.ReAccessNumber));

                    if (result.Status == Service.Status.OK)
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "비밀번호 변경이 완료 되었습니다.", "OK");
                        await this.BackProcess();
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Warning", result.Message, "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", ex.Message, "OK");
            }
            finally
            {
                this.ActivityIndicator = false;
                this.IsEnabledControl = true;
                (this.JoinCommand as Command).ChangeCanExecute();
            }
        }

        internal async Task BackProcess()
        {
            this.IsEnabledControl = false;
            this.ActivityIndicator = true;
            (this.BackCommand as Command).ChangeCanExecute();

            await ((NavigationPage)Application.Current.MainPage).PopAsync();

            this.ActivityIndicator = false;
            this.IsEnabledControl = true;
            (this.BackCommand as Command).ChangeCanExecute();
        }
        #endregion


        #region ETC
        #endregion
    }
}