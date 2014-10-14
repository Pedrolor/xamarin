using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ComunicacionEntreFormularios
{
	[Activity (Label = "ComunicacionEntreFormularios", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button btnLlamar = FindViewById<Button> (Resource.Id.btnLlamaDatos);

			btnLlamar.Click += (object sender, EventArgs e) => {
				var miActivity = new Intent(this,typeof(RecogeDatosActivity));

				EditText TxtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
				miActivity.PutExtra("nombre", TxtNombre.Text);
				StartActivityForResult(miActivity,1);
			};
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data){
			base.OnActivityResult(requestCode, resultCode, data);

			string mensaje = "";

			switch (requestCode) {
			case 1:
				string nombre = data.GetStringExtra ("nombre");
				string apellidos = data.GetStringExtra ("apellidos");
				string edad = data.GetStringExtra ("edad");
				mensaje= "Bienvenido " + nombre + " " + apellidos + " ya te han caido " + edad + " anos.";
				break;
			default:
				mensaje = "No se ha llamado desde este Activity";
				break;
			}

			// Prueba para ver si sube la version
			Toast.MakeText (this, mensaje, ToastLength.Long).Show();
		}
	}
}


