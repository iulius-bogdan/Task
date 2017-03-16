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
using PerpetualEngine.Storage;
using Newtonsoft.Json;
using Task.Resources;

namespace Task
{
    [Activity(Label = "AfisareOrar")]
    public class AfisareOrar : Activity
    {
        //ggg

        List<Data2> ObjectList= new List<Data2>();

        TextView OraView;
        TextView MatView;
        int counter=1;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AfisareOrarView);

            string ZiuaSelect = Intent.GetStringExtra("Ziua") ?? "Data not available";

            var storage = SimpleStorage.EditGroup("DB");

           var ZiuaSe = storage.Get(ZiuaSelect);

            ObjectList = JsonConvert.DeserializeObject<List<Data2>>(ZiuaSe);

            var FirstObj = ObjectList.First();

                MatView = FindViewById<TextView>(Resource.Id.textView3);

           
                OraView = FindViewById<TextView>(Resource.Id.textView4);

            MatView.Text = FirstObj.Materie;

            OraView.Text = FirstObj.Ora;

            var button = FindViewById<Button>(Resource.Id.button5);

            button.Click += Button_Click;



        }

        private void Button_Click(object sender, EventArgs e)
        {

            var FirstObj = ObjectList.ElementAt(counter);
            counter += 1;
            MatView.Text = FirstObj.Materie;

            OraView.Text = FirstObj.Ora;

            if (counter >= ObjectList.Count)
                counter = 0;

        }
    }
}