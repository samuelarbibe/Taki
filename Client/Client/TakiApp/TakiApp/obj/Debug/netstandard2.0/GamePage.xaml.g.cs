//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("TakiApp.GamePage.xaml", "GamePage.xaml", typeof(global::TakiApp.GamePage))]

namespace TakiApp {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("GamePage.xaml")]
    public partial class GamePage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button ExitGameButton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::TakiApp.UserControls.Player1UC uc1;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(GamePage));
            ExitGameButton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Button>(this, "ExitGameButton");
            uc1 = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::TakiApp.UserControls.Player1UC>(this, "uc1");
        }
    }
}