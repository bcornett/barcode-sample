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
