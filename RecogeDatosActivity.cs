
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ComunicacionEntreFormularios
{
	[Activity (Label = "RecogeDatosActivity")]			
	public class RecogeDatosActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.RecogeDatos);

			TextView txtNombre = FindViewById<TextView> (Resource.Id.txtNombreDatos);
			txtNombre.Text = Intent.GetStringExtra ("nombre");

			Button btnAceptar = FindViewById<Button> (Resource.Id.btnAceptar);

			btnAceptar.Click += (sender, e) => {
				Intent miActivity = new Intent(this,typeof(MainActivity));

				miActivity.PutExtra("nombre",txtNombre.Text);

				EditText txtApellidos = FindViewById<EditText> (Resource.Id.txtApellidos);
				miActivity.PutExtra("apellidos",txtApellidos.Text);

				EditText txtEdad = FindViewById<EditText> (Resource.Id.txtEdad);
				miActivity.PutExtra("nombre",txtEdad.Text);

				SetResult (Result.Ok, miActivity);
				Finish();
			};
		}
	}
}
