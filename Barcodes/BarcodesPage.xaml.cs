using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Barcodes
{
    public partial class BarcodesPage : ContentPage
    {
        public BarcodesPage()
        {
            InitializeComponent();
        }

		protected override void OnAppearing()
		{
            btnScan.Clicked += ScanBarcode;
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
            btnScan.Clicked -= ScanBarcode;
            base.OnDisappearing();
		}

		private async void ScanBarcode(object sender, EventArgs e) 
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
        }
	}
}
